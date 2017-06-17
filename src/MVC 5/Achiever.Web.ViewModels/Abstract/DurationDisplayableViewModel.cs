using System;
using System.ComponentModel.DataAnnotations;

namespace Achiever.Web.ViewModels.Abstract
{
    public abstract class DurationDisplayableViewModel : BaseViewModel
    {
        public virtual TimeSpan Duration { get; set; }

        [Required]
        public int? Hours
        {
            get
            {
                return this.Duration.Hours;
            }
            set
            {
                int val = 0;
                if (value != null)
                {
                    val = value.Value;
                }

                TimeSpan newTs = new TimeSpan(val, this.Minutes.Value, 0);
                this.Duration = newTs;
            }
        }
        [Required]
        public int? Minutes
        {
            get
            {
                return this.Duration.Minutes;
            }
            set
            {
                int val = 0;
                if (value != null)
                {
                    val = value.Value;
                }

                TimeSpan newTs = new TimeSpan(this.Hours.Value, val, 0);
                this.Duration = newTs;
            }
        }

        public virtual string DurationAsString
        {
            get
            {
                string time = string.Empty;

                if (this.Hours > 0 && this.Minutes > 0)
                {
                    time = string.Format("{0}h {1}min", this.Hours, this.Minutes);
                }
                else if (this.Hours > 0 && !(this.Minutes > 0))
                {
                    time = string.Format("{0}h", this.Hours);
                }
                else
                {
                    time = string.Format("{0}min", this.Minutes);
                }

                return time;
            }
        }
    }
}
