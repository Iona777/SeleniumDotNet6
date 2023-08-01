using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V112.DOM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static OrangeHRMDotNet6TestProject.Utilities.GetElements;

namespace OrangeHRMDotNet6TestProject.Utilities
{
    public static class Tables
    {
        /// <summary>
        /// Waits for the table webElement using the given By.
        /// Returns the row and index nRow
        /// NOTE: This is zero referenced (although for some tables, row 0 is the headings)
        /// </summary>
        /// <param name="by">Used to locate the element, e.g. By.Id("xyz")</param>
        /// <param name="tagName">Tag name to idenfify the table rows. Usually "tr" but could vary</param>
        /// <param name="nRow">Index of the row to return</param>
        /// <returns></returns>
        public static IWebElement GetTableNthRow(By by, String tagName,int nRow)
        {
            var tableElement = GetVisibleElement(by);
            Assert.IsNotNull(tableElement, $"Did not find the table given by: {by}");
            Assert.AreEqual("table", tableElement.TagName, $"Element given by: {by} is not a table!");


            //Alternatively:
            //Tag name may vary so use paramenter. minCount and waitSeconds will have default values if not specified
            //Since we are not giving values for ALL the parameters (retry not given), we need to give the parameter in t
            //in the form 'parameter: value'

            //var webElements = GetAllVisibleElements(By.TagName(tagName), minCount: 2, waitSeconds: 2);

            //Tag name may vary so use paramenter
            var webElements = tableElement.FindElements(By.TagName(tagName));

            try
            {
                Assert.IsNotNull(webElements.ElementAt(nRow), $"Did not find any data a row index: {nRow}");
            }
            catch (ArgumentOutOfRangeException e)
            {
                throw;
            }

            return webElements[nRow];
        }


        /// <summary>
        /// Waits for the table webElement using the given By.
        /// Returns the column and index nCol
        /// NOTE: This is zero referenced 
        /// </summary>
        /// <param name="by">Used to locate the element, e.g. By.Id("xyz")</param>
        /// <param name="tagname">Tag name to idenfify the table column. Usually "td" but could vary</param>
        /// <param name="nCol">Index of the column to return</param>
        /// <returns></returns>
        public static IWebElement GetTableNthColumn(By by, string tagName, int nCol)
        {
            var tableElement = GetVisibleElement(by);
            Assert.IsNotNull(tableElement, $"Did not find the table given by: {by}");
            Assert.AreEqual("table", tableElement.TagName, $"Element given by: {by} is not a table!");

            //Tag name may vary so use paramenter
            var webElements = tableElement.FindElements(By.TagName(tagName));

            try
            {
                Assert.IsNotNull(webElements.ElementAt(nCol), $"Did not find any data a column index: {nCol}");
            }
            catch (ArgumentOutOfRangeException e)
            {
                throw;
            }

            return webElements[nCol];
        }


        public static IWebElement GetTableNthRowAndColumn(By by, string rowTagName,string colTagName,int nRow, int nCol)
        {
            var tableElement = GetVisibleElement(by);
            Assert.IsNotNull(tableElement, $"Did not find the table given by: {by}");
            Assert.AreEqual("table", tableElement.TagName, $"Element given by: {by} is not a table!");

            //Tag names may vary so use paramenters
            var rows = tableElement.FindElements(By.TagName(rowTagName));
            var nthRow = rows[nRow];
           
            var columns = nthRow.FindElements(By.TagName(colTagName));
            var nthRowCol = columns[nCol];

            return nthRowCol;
        }

        /// <summary>
        /// Checks to see if all the displayed columns in the table contain the expected text
        /// </summary>
        /// <param name="by">Used to locate the element, e.g. By.Id("xyz")</param>
        /// <param name="colTagName">Tag name to identify columns</param>
        /// <param name="expectedText">Text each column should equal</param>
        /// <returns></returns>
        public static bool AllNthColumsContainSpecifiedText(By by, string colTagName, string expectedText)
        {
            bool allColumnsEqualText = true;
            var tableElement = GetVisibleElement(by);
            var columns = tableElement.FindElements(By.TagName(colTagName));

            foreach ( var column in columns ) 
            {
                if (column.Displayed)
                {
                    if (!column.Text.Equals(expectedText))
                    {
                        allColumnsEqualText = false;
                        break;
                    }
                }
            }

            return allColumnsEqualText;
        }
    }
}
