using Laserfiche.Custom.Activities;
using Laserfiche.Custom.Activities.Design;
using Laserfiche.Workflow.Activities;
using Laserfiche.Workflow.ComponentModel;
using LFSO90Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Workflow.ComponentModel;

namespace WFCustoms02
{
    public class ClassWFCustoms02Activity : CustomSingleEntryActivity
    {

        private string uInput = "";

        public string UInput
        {
            get { return this.uInput; }
            set { this.uInput = value; }
        }

        /// <summary>
        /// CHRIS KUBHEKA 
        /// KDZA 
        /// 2021 
        /// </summary>
        
        protected override ActivityExecutionStatus Execute(ActivityExecutionContext executionContext)
        {
            using (ConnectionWrapper wrapper = executionContext.OpenConnection90())
            {
                ILFDatabase database = (ILFDatabase)wrapper.Database;

                LaserficheEntryInfo entryInfo = this.GetEntryInformation(executionContext);
                ILFEntry entry = (ILFEntry)database.GetEntryByID(entryInfo.Id);
                entry.Name = this.UInput;

                //database.GetAndLockEntryByID(uInput);
                ILFDocument document = (ILFDocument)entry;

                string name = this.ResolveTokensInText(executionContext, this.UInput);
            }

            return base.Execute(executionContext);
        }

    }
}
