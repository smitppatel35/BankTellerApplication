using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Bank_Teller_Application
{
    class Crud
    {
        private string file_name = @"C:\Users\Smit patel\Desktop\Accounts.dat";

        public string find(string AccountNumber)
        {
            string line = null;
            string accountNumber = null;

            try
            {
                using (var reader = new StreamReader(file_name))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (String.Equals(line.Split(',')[0].Trim(), AccountNumber))
                        {
                            accountNumber = line.Split(',')[0].Trim();
                            
                            break;
                        }
                    }

                    reader.Close();

                    if (accountNumber != null)
                    {
                        System.Windows.Forms.MessageBox.Show("Account Found!:" + line);
                        return line;
                    } else
                    {
                        System.Windows.Forms.MessageBox.Show("Account Not Found.");
                        return null;
                    }
                    
                }
            } catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return null;
            }
        }

        public void updateAmount(string AccountNumber, string amountNew)
        {
            string line = null;
            bool updated = false;
            int numLine = 0;
            try
            {
                using (var reader = new StreamReader(file_name))
                {
                   
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (String.Equals(line.Split(',')[0].Trim(), AccountNumber))
                        {
                            line = line.Replace(line.Split(',')[2].Trim(), amountNew);
                            
                            updated = true;
                            numLine++;
                            break;
                        }
                    }

                    reader.Close();

                    if (updated && numLine != 0)
                    {
                       
                        string[] arrLines = File.ReadAllLines(file_name);
                        arrLines[numLine] = line;
                        File.WriteAllLines(file_name, arrLines);
                        
                        System.Windows.Forms.MessageBox.Show("Amount Updated.");
                        
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("Failed to update amount.");
                        
                    }

                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                
            }
        }
    }

    
}
