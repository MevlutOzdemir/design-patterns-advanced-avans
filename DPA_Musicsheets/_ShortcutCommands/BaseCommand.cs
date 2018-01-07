using DPA_Musicsheets._ChainOfResponsibility;
using DPA_Musicsheets.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets._Shortcuts {
    public abstract class BaseCommand : IShortcutCommand, IChain {

        private IChain _nextInChain;
        public string Pattern { get; set; }

        protected FileHandler FileHandler { get; set; }

        protected BaseCommand(string pattern) {
            Pattern = pattern;
        }

        public void SetNextChain(IChain nextChain) {
            this._nextInChain = nextChain;
        }

        public void Handle(FileHandler handler, string commandWanted) {
            if (CurrentChainCanHandle(commandWanted))
                this.Execute(handler);
            else
                this._nextInChain?.Handle(handler, commandWanted);
        }

        public bool CurrentChainCanHandle(string commandWanted) {
            return this.Pattern == commandWanted;
        }

        public void Execute(FileHandler fileHandler) {
            this.FileHandler = fileHandler;
            this.Execute();
        }

        protected abstract void Execute();
        public abstract BaseCommand Clone();
    }
}
