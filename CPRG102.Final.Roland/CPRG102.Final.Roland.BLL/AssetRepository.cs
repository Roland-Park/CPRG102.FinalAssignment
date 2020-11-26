using CPRG102.Final.Roland.Data;
using CPRG102.Final.Roland.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPRG102.Final.Roland.BLL
{
    public interface IAssetRepository
    {
        List<Asset> GetAllAssets();
        List<Asset> GetAssetsAssignedToEmployee(string employeeId);
        List<Asset> GetUnassignedAssets();
        List<Asset> GetAssetsByType(int assetId);
        void CreateAsset(Asset asset);
        void DeleteAsset(int assetId);
        void UpdateAsset(Asset asset);
    }
    public class AssetRepository : IAssetRepository
    {
        private readonly AssetContext assetContext;

        public AssetRepository(AssetContext assetContext)
        {
            this.assetContext = assetContext;
        }

        public List<Asset> GetAllAssets()
        {
            try
            {
                return assetContext.Assets.Include("AssetType").Include("Manufacturer").Include("Model").ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching asset(s). " + ex.Message);
            }
        }

        public List<Asset> GetAssetsAssignedToEmployee(string employeeId)
        {
            try
            {
                return assetContext.Assets.Include("AssetType").Include("Manufacturer").Include("Model").Where(x => x.AssignedTo == employeeId).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching asset(s). " + ex.Message);
            }
        }

        public List<Asset> GetUnassignedAssets()
        {
            try
            {
                return assetContext.Assets.Include("AssetType").Include("Manufacturer").Include("Model").Where(x => string.IsNullOrWhiteSpace(x.AssignedTo)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching asset(s). " + ex.Message);
            }
        }

        public List<Asset> GetAssetsByType(int assetTypeId)
        {
            try
            {
                return assetContext.Assets.Include("Manufacturer").Include("Model").Where(x => x.AssetTypeId == assetTypeId).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching asset(s). " + ex.Message);
            }
        }

        public void CreateAsset(Asset asset)
        {
            try
            {
                assetContext.Assets.Add(asset);
                assetContext.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new Exception("Error creating asset. " + ex.Message);
            }            
        }

        public void DeleteAsset(int assetId)
        {
            try
            {
                var allAssets = assetContext.Assets;
                var assetToDelete = allAssets.FirstOrDefault(x => x.Id == assetId);
                if (assetToDelete != null)
                {
                    assetContext.Assets.Remove(assetToDelete);
                    assetContext.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Error deleting asset. " + ex.Message);
            }            
        }

        public void UpdateAsset(Asset asset)
        {
            try
            {
                var allAssets = assetContext.Assets;
                var assetToUpdate = allAssets.FirstOrDefault(x => x.Id == asset.Id);

                if (assetToUpdate != null && asset != null)
                {
                    allAssets.Update(assetToUpdate);
                    assetContext.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Error updating asset. " + ex.Message);
            }
        }
    }
}
