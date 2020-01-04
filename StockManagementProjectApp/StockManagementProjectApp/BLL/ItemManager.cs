using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementProjectApp.DAL.Gateway;
using StockManagementProjectApp.DAL.Modals;
using StockManagementProjectApp.DAL.Modals.ViewModel;

namespace StockManagementProjectApp.BLL
{
    public class ItemManager
    {
        ItemGateway itemGateway = new ItemGateway();

        public string SaveItem(Item item)
        {
            if (itemGateway.IsItemExist(item))
            {
                return "Item Already Exist...";
            }
            int rowAffect = itemGateway.SaveItem(item);
            if (rowAffect > 0)
            {
                return "Item Saved Succesfully";
            }
            return "Item Save Failed"; 
        }

        public List<ItemViewModel> GetItemsByCompanyId(int companyId)
        {
            return itemGateway.GetItemsByCompanyId(companyId);
        }

        public ItemViewModel GetItemByItemId(int itemId)
        {
            return itemGateway.GetItemByItemId(itemId);
        }

        public string StockInItem(int totalQuantity, int itemId)
        {
            if (itemGateway.StockInItem(totalQuantity,itemId)>0)
            {
                return "Item Stocked";
            }

            return "Item Stock Failed";
        }

        public List<ItemViewModel> GetItemsByCatagoryId(int catagoryId)
        {
            return itemGateway.GetItemsByCatagoryId(catagoryId);
        }

        public List<ItemViewModel> GetItemsByCompanyIdAndCatagoryId(int companyId, int catagoryId)
        {
            return itemGateway.GetItemsByCompanyIdAndCatagoryId(companyId, catagoryId);
        }
    }

}