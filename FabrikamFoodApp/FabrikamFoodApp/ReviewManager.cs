using Microsoft.WindowsAzure.MobileServices;
using FabrikamFoodApp.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabrikamFoodApp
{
    public class ReviewManager
    {

        private static ReviewManager instance;
        private MobileServiceClient client;
        private IMobileServiceTable<ReviewClass> reviewsTable;

        private ReviewManager()
        {
            this.client = new MobileServiceClient("http://fabrikamfoodsuk.azurewebsites.net");
            this.reviewsTable = this.client.GetTable<ReviewClass>();
        }

        public MobileServiceClient AzureClient
        {
            get { return client; }
        }

        public static ReviewManager ReviewManagerInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ReviewManager();
                }

                return instance;
            }
        }
        //CRUD:
        //Create
        public async Task AddReview(ReviewClass review)
        {
            await this.reviewsTable.InsertAsync(review);
        }

        //Read
        public async Task<List<ReviewClass>> GetReviews()
        {
            return await this.reviewsTable.ToListAsync();
        }

        //Update
        public async Task UpdateReview(ReviewClass review)
        {
            await this.reviewsTable.UpdateAsync(review);
        }
        //Delete
        public async Task DeleteReview(ReviewClass review)
        {
            await this.reviewsTable.DeleteAsync(review);
        }
    }
}
