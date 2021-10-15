using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CentrostalAPI.DB.IRepositories;
using CentrostalAPI.DB.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CentrostalAPI.DB.Repositories {
    public class StatusRepository : GenericRepository<Status>, IStatusRepository {
        public StatusRepository(ApplicationDbContext context) : base(context) {
        }

        public static void seed(EntityTypeBuilder<Status> builder) {
            builder.HasData(

                ///// SUPPPLY
                new Status() {
                    id = 1,
                    name = "edytowalne",
                    canAdminCancel = true,
                    canAdminChangeStatus = true,
                    canAdminEdit = true,
                    canAnyoneCancel = true,
                    canAnyoneChangeStatus = true,
                    canAnyoneEdit = true,
                    canChairmanCancel = true,
                    canChairmanChangeStatus = true,
                    canChairmanEdit = true,
                    color = "#999966",
                    nextStatusMsg = "Przekaż dalej",
                    nextStatusId = 2
                },
                new Status() {
                    id = 2,
                    name = "utworzone",
                    canAnyoneCancel = false,
                    canAnyoneChangeStatus = false,
                    canAnyoneEdit = false,
                    canChairmanCancel = false,
                    canChairmanChangeStatus = false,
                    canChairmanEdit = false,
                    canAdminCancel = true,
                    canAdminChangeStatus = true,
                    canAdminEdit = true,
                    color = "#99cc00",
                    nextStatusMsg = "Oznacz jako zapytane",
                    nextStatusId = 3
                },
                new Status() {
                    id = 3,
                    name = "zapytane",
                    canAnyoneCancel = false,
                    canAnyoneChangeStatus = false,
                    canAnyoneEdit = false,
                    canChairmanCancel = false,
                    canChairmanChangeStatus = false,
                    canChairmanEdit = false,
                    canAdminCancel = true,
                    canAdminChangeStatus = true,
                    canAdminEdit = true,
                    color = "#cc66ff",
                    shouldShowPrice = true,
                    nextStatusMsg = "Przekaż do zatwierdzenia",
                    nextStatusId = 4
                },
                new Status() {
                    id = 4,
                    name = "niezatwierdzone",
                    canAnyoneCancel = false,
                    canAnyoneChangeStatus = false,
                    canAnyoneEdit = false,
                    canChairmanCancel = true,
                    canChairmanChangeStatus = true,
                    canChairmanEdit = true,
                    canAdminCancel = true,
                    canAdminChangeStatus = false,
                    canAdminEdit = true,
                    shouldShowPrice = true,
                    color = "#ff6600",
                    nextStatusMsg = "Zatwierdź",
                    nextStatusId = 5
                },
                new Status() {
                    id = 5,
                    name = "zatwierdzone",
                    canAnyoneCancel = false,
                    canAnyoneChangeStatus = false,
                    canAnyoneEdit = false,
                    canChairmanCancel = false,
                    canChairmanChangeStatus = false,
                    canChairmanEdit = false,
                    canAdminCancel = true,
                    canAdminChangeStatus = true,
                    canAdminEdit = true,
                    shouldShowPrice = true,
                    color = "#33cc33",
                    nextStatusMsg = "Oznacz jako zamówione",
                    nextStatusId = 6
                },
                new Status() {
                    id = 6,
                    name = "zamówione",
                    canAnyoneCancel = false,
                    canAnyoneChangeStatus = false,
                    canAnyoneEdit = false,
                    canChairmanCancel = false,
                    canChairmanChangeStatus = false,
                    canChairmanEdit = false,
                    canAdminCancel = true,
                    canAdminChangeStatus = true,
                    canAdminEdit = true,
                    shouldShowPrice = true,
                    color = "#0066cc",
                    nextStatusMsg = "Przyjmuję towar",
                    nextStatusId = 7
                },
                new Status() {
                    id = 7,
                    name = "zrealizowane",
                    canAnyoneCancel = false,
                    canAnyoneChangeStatus = false,
                    canAnyoneEdit = false,
                    canChairmanCancel = false,
                    canChairmanChangeStatus = false,
                    canChairmanEdit = false,
                    canAdminCancel = false,
                    canAdminChangeStatus = false,
                    canAdminEdit = false,
                    shouldShowPrice = true,
                    color = "#009933",
                    shouldUpdateAmount = true
                },

                ///////// SUPPLY AND RELEASE
                new Status() {
                    id = 8,
                    name = "anulowane",
                    canAnyoneCancel = false,
                    canAnyoneChangeStatus = false,
                    canAnyoneEdit = false,
                    canChairmanCancel = false,
                    canChairmanChangeStatus = false,
                    canChairmanEdit = false,
                    canAdminCancel = false,
                    canAdminChangeStatus = false,
                    canAdminEdit = false,
                    color = "#cc0000",
                },


                 /////// RELEASE
                 new Status() {
                     id = 9,
                     name = "edytowalne",
                     canAdminCancel = true,
                     canAdminChangeStatus = true,
                     canAdminEdit = true,
                     canAnyoneCancel = true,
                     canAnyoneChangeStatus = true,
                     canAnyoneEdit = true,
                     canChairmanCancel = true,
                     canChairmanChangeStatus = true,
                     canChairmanEdit = true,
                     color = "#999966",
                     nextStatusMsg = "Wydaj",
                     nextStatusId = 10
                 },
                new Status() {
                    id = 10,
                    name = "wydane",
                    canAnyoneCancel = false,
                    canAnyoneChangeStatus = false,
                    canAnyoneEdit = false,
                    canChairmanCancel = false,
                    canChairmanChangeStatus = false,
                    canChairmanEdit = false,
                    canAdminCancel = false,
                    canAdminChangeStatus = false,
                    canAdminEdit = false,
                    color = "#009933",
                    shouldUpdateAmount = true
                }
            );
        }
    }

    public enum Statuses {
        /// order - supply
        editableSupply = 1,
        created = 2,
        asked = 3,
        unaccepted = 4,
        accepted = 5,
        ordered = 6,
        realized = 7,

        canceled = 8,

        editableGiving = 9,
        given = 10,
    }
}
