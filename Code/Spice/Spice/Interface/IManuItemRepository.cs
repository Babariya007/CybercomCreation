using Spice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spice.Interface
{
    public interface IManuItemRepository
    {
        ManuItem GetManuItemByID(int id);
        IEnumerable<ManuItem> GetAllManuItem();
        ManuItem AddManuItem(ManuItem manuItem);
        ManuItem EditManuItem(ManuItem manuItemChange);
        bool DeleteManuItem(int id);
    }
}
