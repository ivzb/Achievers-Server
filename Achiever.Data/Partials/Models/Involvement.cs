namespace Achiever.Data
{
    using Achiever.Data.Common.Models;
    using System;

    public partial class Involvement : BaseModel<int>
    {
        public override bool Equals(Object obj)
        {
            if (obj == null) return false;

            Involvement other = obj as Involvement;

            if ((Object)other == null) return false;
            if (this.Id != other.Id) return false;

            return true;
        }

        public override int GetHashCode()
        {
            return this.Id;
        }
    }
}