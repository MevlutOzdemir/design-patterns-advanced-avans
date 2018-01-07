using DPA_Musicsheets.ViewModels;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets._Shortcuts {
    class OpenFileCommand : BaseCommand {

        public OpenFileCommand() : base("LeftCtrlO") {
        }

        public override BaseCommand Clone() {
            return new OpenFileCommand();
        }

        protected override void Execute() {
            var mainVM = SimpleIoc.Default.GetInstance<MainViewModel>();

            if (mainVM.OpenFileCommand.CanExecute(null)) {
                mainVM.OpenFileCommand.Execute(null);
            }
        }
    }
}
