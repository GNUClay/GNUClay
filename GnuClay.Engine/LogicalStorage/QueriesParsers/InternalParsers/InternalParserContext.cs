using GnuClay.Engine.CommonStorages;
using GnuClay.Engine.LogicalStorage.InternalStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.LogicalStorage.QueriesParsers.InternalParsers
{
    public class InternalParserContext
    {
        public InternalParserContext(List<Token> source, StorageDataDictionary dataDictionary)
        {
            mSource = new Queue<Token>(source);
            mStorageDataDictionary = dataDictionary;
        }

        private Queue<Token> mSource = null;
        private StorageDataDictionary mStorageDataDictionary = null;

        public StorageDataDictionary DataDictionary
        {
            get
            {
                return mStorageDataDictionary;
            }
        }

        public Token Read()
        {
            if(mSource.Count == 0)
            {
                return null;
            }

            return mSource.Dequeue();
        }

        public void Recovery(Token token)
        {
            var tmpOldList = mSource.ToList();

            var tmpNewList = new List<Token>() { token };
            tmpNewList.AddRange(tmpOldList);

            mSource = new Queue<Token>(tmpNewList);
        }

        public bool IsEmpty()
        {
            return mSource.Count == 0;
        }
    }
}
