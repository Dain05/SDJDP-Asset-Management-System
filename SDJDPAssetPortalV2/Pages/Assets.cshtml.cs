using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SDJDPAssetPortalV2.Data;
using SDJDPAssetPortalV2.Models;

namespace SDJDPAssetPortalV2.Pages
{
    public class AssetsModel : PageModel
    {
        public List<Asset> Assets { get; set; } = new List<Asset>();

        [BindProperty]
        public Asset NewAsset { get; set; } = new Asset();

        [BindProperty]
        public Asset UpdateAssetData { get; set; } = new Asset();

        [BindProperty]
        public string SearchText { get; set; } = "";

        public void OnGet()
        {
            LoadAssets();
        }

        public IActionResult OnPostAdd()
        {
            AssetRepository repo = new AssetRepository();
            repo.AddAsset(NewAsset);

            return RedirectToPage();
        }

        public IActionResult OnPostUpdate()
        {
            AssetRepository repo = new AssetRepository();
            repo.UpdateAsset(UpdateAssetData);

            return RedirectToPage();
        }

        public IActionResult OnPostDelete(string assetID)
        {
            AssetRepository repo = new AssetRepository();
            repo.DeleteAsset(assetID);

            return RedirectToPage();
        }

        public void OnPostSearch()
        {
            AssetRepository repo = new AssetRepository();

            if (string.IsNullOrWhiteSpace(SearchText))
            {
                Assets = repo.GetAssets();
            }
            else
            {
                Assets = repo.SearchAssets(SearchText);
            }
        }

        private void LoadAssets()
        {
            AssetRepository repo = new AssetRepository();
            Assets = repo.GetAssets();
        }
    }
}