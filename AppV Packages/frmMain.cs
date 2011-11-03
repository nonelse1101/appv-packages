/// AppV Package Listing Tool
/// Created by: Justin Mangum
/// parabola949@gmail.com
/// 
/// Note:  I'm all for open source, but wouldn't mind credit where credit is due.  
/// If you use this code for commercial applications, at least give me a mention :)

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.DirectoryServices;
using System.Security.Principal;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
//using System.Runtime.InteropServices;


namespace AppV_Packages
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Check to see if there is a connection string already stored in the users settings
            if (AppV_Packages.Properties.Settings.Default.UserConnectionString == "")
            {
                //Get connection info
                frmConnection objfrmConnection = new frmConnection();
                objfrmConnection.ShowDialog();
            }
            //Begin working
            DoWork();


        }

        /// <summary>
        /// Perform SQL Query and build Data
        /// </summary>
        /// <param name="myConnection">Connection string</param>
        /// <returns></returns>
        public DataSet GetData(SqlConnection myConnection)
        {
            DataSet AppVData = new DataSet();

            try
            {
                myConnection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(@"SELECT     Assignments.id, Assignments.group_ref AS [AD Group], Assignments.app_id, Groups.app_group_id, Groups.name, 
                      CASE WHEN Groups.parent_id IS NULL THEN '0' ELSE Groups.parent_id END AS Parent, Applications.package_id, Applications.version, 
                      Applications.enabled, Applications.name AS [Application Name], Packages.name AS [Package Name]
FROM         APPLICATION_ASSIGNMENTS AS Assignments FULL OUTER JOIN
                      APPLICATIONS AS Applications ON Assignments.app_id = Applications.app_id FULL OUTER JOIN
                      APPLICATION_GROUPS AS Groups ON Applications.app_group_id = Groups.app_group_id FULL OUTER JOIN
                      PACKAGES AS Packages ON Applications.package_id = Packages.package_id
WHERE     (Groups.app_group_id IS NOT NULL)
ORDER BY Groups.parent_id ASC, Groups.app_group_id DESC", myConnection);
                myReader = myCommand.ExecuteReader();

                #region Create table
                DataTable AppVTable = new DataTable();
                AppVTable.TableName = "AppV Packages";

                DataColumn packageID = new DataColumn("ID", typeof(string));   //0
                packageID.AutoIncrement = true;
                packageID.AutoIncrementSeed = 101;
                packageID.AutoIncrementStep = 1;

                AppVTable.Columns.Add(packageID);

                // AppVTable.PrimaryKey = new DataColumn[] { packageID };


                AppVTable.Columns.Add(new DataColumn("ADGroup"));       //1
                AppVTable.Columns.Add(new DataColumn("App ID"));        //2
                AppVTable.Columns.Add(new DataColumn("Group ID"));      //3
                AppVTable.Columns.Add(new DataColumn("Group Name"));    //4
                AppVTable.Columns.Add(new DataColumn("Parent ID"));     //5
                AppVTable.Columns.Add(new DataColumn("Package ID"));    //6
                AppVTable.Columns.Add(new DataColumn("Version"));       //7
                AppVTable.Columns.Add(new DataColumn("Enabled"));       //8
                AppVTable.Columns.Add(new DataColumn("App Name"));      //9
                AppVTable.Columns.Add(new DataColumn("Package Name"));  //10
                #endregion
                #region Build table
                while (myReader.Read())
                {
                    DataRow row = AppVTable.NewRow();
                    for (int i = 0; i < myReader.FieldCount; i++)
                    {
                        try
                        {
                            row[i] = myReader[i].ToString();
                        }
                        catch
                        {
                            row[i] = "0";
                        }

                        Application.DoEvents();
                    }
                    AppVTable.Rows.Add(row);
                }
                #endregion
                AppVData.Tables.Add(AppVTable);
                //dataGridView1.DataSource = AppVData.Tables[0];
                return AppVData;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Function to actually build the TreeView based on the Data gathered
        /// </summary>
        /// <param name="Data"></param>
        public void BuildTree(DataSet Data)
        {

            DataTable myTable = Data.Tables[0];
            //int numRows = myTable.Rows.Count;
            //int numCols = myTable.Columns.Count;
            #region Build TreeView
            foreach (DataRow row in myTable.Rows)
            {
                string row0 = row[0].ToString(), row1 = row[1].ToString(), row2 = row[2].ToString();
                string row3 = row[3].ToString(), row4 = row[4].ToString(), row5 = row[5].ToString();
                string row6 = row[6].ToString(), row7 = row[7].ToString(), row8 = row[8].ToString();
                string row9 = row[9].ToString(), row10 = row[10].ToString();

                row1 = GetNameFromSID(row1);
                string tag = row7 + ":" + row1 + ":" + row10 + ":" + row8;

                if (row5 == "0") //Root node
                {
                    if (!AppVTree.Nodes.ContainsKey(row3))
                    {
                        AppVTree.SelectedNode = AppVTree.Nodes.Add(row3, row4);

                    }
                    else
                    {
                        int i = AppVTree.Nodes.IndexOfKey(row3);
                        AppVTree.Nodes[i].Text = row4;
                    }

                    AppVTree.SelectedNode = AppVTree.Nodes[AppVTree.Nodes.IndexOfKey(row3)].Nodes.Add(row6, row9);
                    AppVTree.SelectedNode.Tag = tag;
                }
                else if (AppVTree.Nodes.ContainsKey(row5)) //Subnode
                {
                    int i = AppVTree.Nodes.IndexOfKey(row5);
                    if (AppVTree.Nodes[i].Nodes.ContainsKey(row3))
                    {
                        AppVTree.SelectedNode = AppVTree.Nodes[i].Nodes[AppVTree.Nodes[i].Nodes.IndexOfKey(row3)].Nodes.Add(row6, row9);
                        AppVTree.SelectedNode.Tag = tag;
                    }
                    else
                    {
                        AppVTree.SelectedNode = AppVTree.Nodes[i].Nodes.Add(row3, row4);
                        AppVTree.SelectedNode = AppVTree.SelectedNode.Nodes.Add(row6, row9);
                        AppVTree.SelectedNode.Tag = tag;
                    }
                    
                }
                
                else //node not found, or 3rd level node
                {
                    bool found = false;
                    foreach (TreeNode node in AppVTree.Nodes)
                    {
                        if (node.Nodes.ContainsKey(row5))
                        {
                            int i = node.Nodes.IndexOfKey(row5);
                            if (node.Nodes[i].Nodes.ContainsKey(row3))
                            {
                                found = true;
                                int x = node.Nodes[i].Nodes.IndexOfKey(row3);
                                node.Nodes[i].Nodes[x].Nodes.Add(row6, row9);
                                int y = node.Nodes[i].Nodes[x].Nodes.IndexOfKey(row6);
                                node.Nodes[i].Nodes[x].Nodes[y].Tag = tag;

                            }
                            else
                            {
                                found = true;
                                node.Nodes[i].Nodes.Add(row3, row4);
                                int x = node.Nodes[i].Nodes.IndexOfKey(row3);
                                if (row6 == "")
                                    row6 = "0";
                                node.Nodes[i].Nodes[x].Nodes.Add(row6, row9);
                                int y = node.Nodes[i].Nodes[x].Nodes.IndexOfKey(row6);
                                node.Nodes[i].Nodes[x].Nodes[y].Tag = tag;
                            }
                        }
                    }
                    if (!found) //Like it says, if no parent node is found
                    {
                        MessageBox.Show(row4);
                    }
                }
            }
            #endregion
            AppVTree.Sort();
            AppVTree.CollapseAll();
        }

        /// <summary>
        /// Removes any blank nodes 
        /// (this happens sometimes due to old entries in the SQL database not clearing properly)
        /// </summary>
        public void CleanTree()
        {
            foreach (TreeNode node in AppVTree.Nodes)
            {
                foreach (TreeNode node2 in node.Nodes)
                {
                    foreach (TreeNode node3 in node2.Nodes)
                    {
                        if (node3.Text == "")
                            node3.Remove();
                    }
                    if (node2.Text == "")
                        node2.Remove();

                }
                if (node.Text == "")
                    node.Remove();
            }

        }

        /// <summary>
        /// Double click on treenode, pops message box displaying information about the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AppVTree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (AppVTree.SelectedNode.Tag != null)
            {
                string[] tag = new string[4];
                tag = AppVTree.SelectedNode.Tag.ToString().Split(':');
                string Message = "Version: " + tag[0] + Environment.NewLine;
                Message += "Active Directory Group: " + tag[1] + Environment.NewLine;
                Message += "Package Name: " + tag[2] + Environment.NewLine;
                Message += "Enabled: " + tag[3];
                MessageBox.Show(Message);
            }
        }

        /// <summary>
        /// SQL Database returns Active Directory Group as SID- convert to readable name
        /// </summary>
        /// <param name="sidd">SID from SQL</param>
        /// <returns></returns>
        string GetNameFromSID(string sidd)
        {
            if (sidd == "")
                return "";
            SecurityIdentifier sid = new SecurityIdentifier(sidd);
            try
            {
                NTAccount acct = (NTAccount)sid.Translate(typeof(NTAccount));
                return acct.Value.Remove(0, 6);
            }
            catch
            {
                return sidd;
            }
        }

        /// <summary>
        /// Releases the excel objects
        /// </summary>
        /// <param name="obj">xclObject</param>
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        /// <summary>
        /// The workload...
        /// </summary>
        private void DoWork()
        {
            //Clear existing results
            AppVTree.Nodes.Clear();
            //open sql connection
            SqlConnection myConnection = new SqlConnection(AppV_Packages.Properties.Settings.Default.UserConnectionString);
            MessageBox.Show(AppV_Packages.Properties.Settings.Default.UserConnectionString);
            DataSet Data = GetData(myConnection);

            //if something is wrong, check server settings
            if (Data == null)
            {
                frmConnection objfrmConnection = new frmConnection();
                objfrmConnection.ShowDialog();
                myConnection = new SqlConnection(AppV_Packages.Properties.Settings.Default.UserConnectionString);
                Data = GetData(myConnection);
                if (Data == null)
                {
                    MessageBox.Show("Please recheck your server settings.");
                    return;
                }
            }
            BuildTree(Data);
            CleanTree();
            txtApp.Text = "";
            txtADGroup.Text = "";
            txtPackage.Text = "";
            txtVersion.Text = "";
            chkEnabled.Checked = false;
        }

        private void toolbtnChange_Click(object sender, EventArgs e)
        {
            frmConnection objfrmConnection = new frmConnection();
            objfrmConnection.ShowDialog();
            DoWork();
        }

        private void toolbtnExport_Click(object sender, EventArgs e)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkbook;
            Excel.Worksheet xlWorksheet;
            object misValue = Missing.Value;

            xlApp = new Excel.ApplicationClass();
            xlWorkbook = xlApp.Workbooks.Add(misValue);

            xlWorksheet = (Excel.Worksheet)xlWorkbook.Worksheets.get_Item(1);
            int i = 2;
            string[] notes = new string[4];
            xlWorksheet.Cells[1, 1] = "Group";
            xlWorksheet.Cells[1, 2] = "Group / Application";
            xlWorksheet.Cells[1, 3] = "Group / Application";
            xlWorksheet.Cells[1, 4] = "Application Name";
            xlWorksheet.Cells[1, 5] = "Version";
            xlWorksheet.Cells[1, 6] = "AD Group Permission";
            xlWorksheet.Cells[1, 7] = "Package Name";
            xlWorksheet.Cells[1, 8] = "Enabled";

            foreach (TreeNode node in AppVTree.Nodes)
            {
                xlWorksheet.Cells[i, 1] = node.Text;
                if (node.Tag != null)
                {
                    notes = node.Tag.ToString().Split(':');
                    xlWorksheet.Cells[i, 5] = notes[0];
                    xlWorksheet.Cells[i, 6] = notes[1];
                    xlWorksheet.Cells[i, 7] = notes[2];
                    xlWorksheet.Cells[i, 8] = notes[3];
                }
                foreach (TreeNode node2 in node.Nodes)
                {
                    xlWorksheet.Cells[i, 2] = node2.Text;
                    if (node2.Tag != null)
                    {
                        notes = node2.Tag.ToString().Split(':');
                        xlWorksheet.Cells[i, 5] = notes[0];
                        xlWorksheet.Cells[i, 6] = notes[1];
                        xlWorksheet.Cells[i, 7] = notes[2];
                        xlWorksheet.Cells[i, 8] = notes[3];
                    }
                    foreach (TreeNode node3 in node2.Nodes)
                    {
                        xlWorksheet.Cells[i, 3] = node3.Text;
                        if (node3.Tag != null)
                        {
                            notes = node3.Tag.ToString().Split(':');
                            xlWorksheet.Cells[i, 5] = notes[0];
                            xlWorksheet.Cells[i, 6] = notes[1];
                            xlWorksheet.Cells[i, 7] = notes[2];
                            xlWorksheet.Cells[i, 8] = notes[3];
                        }
                        foreach (TreeNode node4 in node3.Nodes)
                        {
                            xlWorksheet.Cells[i, 4] = node4.Text;
                            if (node4.Tag != null)
                            {
                                notes = node4.Tag.ToString().Split(':');
                                xlWorksheet.Cells[i, 5] = notes[0];
                                xlWorksheet.Cells[i, 6] = notes[1];
                                xlWorksheet.Cells[i, 7] = notes[2];
                                xlWorksheet.Cells[i, 8] = notes[3];
                            }

                            i++;
                        }
                        i++;
                        }
                    i++;
                }
                i++;
                }

            xlWorkbook.Close(true, misValue, misValue); xlApp.Quit();
            releaseObject(xlWorksheet);
            releaseObject(xlWorkbook);
            releaseObject(xlApp);
            }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            AboutBox1 objAbout = new AboutBox1();
            objAbout.ShowDialog();
        }

        private void AppVTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (AppVTree.SelectedNode.Tag != null)
            {
                string[] tag = new string[4];
                tag = AppVTree.SelectedNode.Tag.ToString().Split(':');
                chkEnabled.Checked = Convert.ToBoolean(tag[3]);
                txtVersion.Text = tag[0];
                txtPackage.Text = tag[2];
                txtADGroup.Text = tag[1];
            }
            txtApp.Text = AppVTree.SelectedNode.Text;

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            foreach (TreeNode node in AppVTree.Nodes)
            {
                if (node.Text.Contains(txtApp.Text))
                {
                    if (node.Tag != null)
                    {
                        if (node.Tag.ToString().Contains(txtADGroup.Text) && node.Tag.ToString().Contains(txtPackage.Text) && node.Tag.ToString().Contains(txtVersion.Text))
                        {
                            node.BackColor = Color.Yellow;
                            node.Expand();
                        }
                        else
                        {
                            node.BackColor = SystemColors.Window;
                            node.Collapse();
                        }
                    }
                    else
                    {
                        if (txtApp.Text != "" && txtADGroup.Text == "" && txtPackage.Text == "" && txtVersion.Text == "")
                            node.BackColor = Color.Yellow;
                    }
                }
                else
                {
                    node.BackColor = SystemColors.Window;
                    node.Collapse();
                }


                foreach (TreeNode node2 in node.Nodes)
                {
                    if (node2.Text.Contains(txtApp.Text))
                    {
                        if (node2.Tag != null)
                        {
                            if (node2.Tag.ToString().Contains(txtADGroup.Text) && node2.Tag.ToString().Contains(txtPackage.Text) && node2.Tag.ToString().Contains(txtVersion.Text))
                            {
                                node2.BackColor = Color.Yellow;
                                node.Expand();
                                node2.Expand();
                            }
                            else
                            {
                                node2.BackColor = SystemColors.Window;
                                node2.Collapse();
                            }
                        }
                        else
                        {
                            if (txtApp.Text != "" && txtADGroup.Text == "" && txtPackage.Text == "" && txtVersion.Text == "")
                                node2.BackColor = Color.Yellow;
                        }
                    }
                    else
                    {
                        node2.BackColor = SystemColors.Window;
                        node2.Collapse();
                    }
                    foreach (TreeNode node3 in node2.Nodes)
                    {
                        if (node3.Text.Contains(txtApp.Text))
                        {
                            if (node3.Tag != null)
                            {
                                if (node3.Tag.ToString().Contains(txtADGroup.Text) && node3.Tag.ToString().Contains(txtPackage.Text) && node3.Tag.ToString().Contains(txtVersion.Text))
                                {
                                    node3.BackColor = Color.Yellow;
                                    node.Expand();
                                    node2.Expand();
                                    node3.Expand();
                                }
                                else
                                {
                                    node3.BackColor = SystemColors.Window;
                                    node3.Collapse();
                                }
                            }
                            else
                            {
                                if (txtApp.Text != "" && txtADGroup.Text == "" && txtPackage.Text == "" && txtVersion.Text == "")
                                    node3.BackColor = Color.Yellow;
                            }
                        }
                        else
                        {
                            node3.BackColor = SystemColors.Window;
                            node3.Collapse();
                        }
                    }
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtADGroup.Text = "";
            txtApp.Text = "";
            txtPackage.Text = "";
            txtVersion.Text = "";
            chkEnabled.Checked = false;
            foreach (TreeNode node in AppVTree.Nodes)
            {
                foreach (TreeNode node2 in node.Nodes)
                {
                    foreach (TreeNode node3 in node2.Nodes)
                    {
                        node3.BackColor = SystemColors.Window;
                        node3.Collapse();
                    }
                    node2.BackColor = SystemColors.Window;
                    node2.Collapse();

                }
                node.BackColor = SystemColors.Window;
                node.Collapse();
            }
        }





    }
}
