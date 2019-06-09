﻿using ProgramTree;

namespace SimpleLang.Visitors
{
    class ThirteenthOptimizationVisitor : ChangeVisitor
    {
        public override void VisitIfNode(IfNode c)
        {
            base.VisitIfNode(c);

            if (c.Stat1 == null && c.Stat2 == null)
                ReplaceStatement(c, null);
        }
    }
}