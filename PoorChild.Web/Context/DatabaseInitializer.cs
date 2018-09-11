namespace PoorChild.Web.Context
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    using System.Data.Entity;
    using System.Transactions;

    using PoorChild.Web.Models;

    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            base.Seed(context);

            using (var transaction = new TransactionScope())
            {
                // Генерация 2 родителей
                var parentDevice1 = new ParentDevice() { AndroidId = "dfca3d538e561ba1", DateTimeDeviceRegisteredInUtc = DateTime.UtcNow.AddDays(-5), ChildDevices = new List<ChildDevice>() };
                var parentDevice2 = new ParentDevice() { AndroidId = "dfca3d538e561ba2", DateTimeDeviceRegisteredInUtc = DateTime.UtcNow.AddDays(-4), ChildDevices = new List<ChildDevice>() };
                context.Devices.Add(parentDevice2);
                context.Devices.Add(parentDevice1);
                context.SaveChanges();

                // Генерация 5 детей
                var childDevice1 = new ChildDevice() { AndroidId = "dfca3d538e561ba3", DateTimeDeviceRegisteredInUtc = DateTime.UtcNow.AddDays(-5).AddMinutes(-5) };
                var childDevice2 = new ChildDevice() { AndroidId = "dfca3d538e561ba4", DateTimeDeviceRegisteredInUtc = DateTime.UtcNow.AddDays(-5).AddMinutes(-6) };
                var childDevice3 = new ChildDevice() { AndroidId = "dfca3d538e561ba5", DateTimeDeviceRegisteredInUtc = DateTime.UtcNow.AddDays(-5).AddMinutes(-7) };
                var childDevice4 = new ChildDevice() { AndroidId = "dfca3d538e561ba6", DateTimeDeviceRegisteredInUtc = DateTime.UtcNow.AddDays(-4).AddMinutes(-6) };
                var childDevice5 = new ChildDevice() { AndroidId = "dfca3d538e561ba7", DateTimeDeviceRegisteredInUtc = DateTime.UtcNow.AddDays(-4).AddMinutes(-7) };
                context.Devices.Add(childDevice1);
                context.Devices.Add(childDevice2);
                context.Devices.Add(childDevice3);
                context.Devices.Add(childDevice4);
                context.Devices.Add(childDevice5);
                context.SaveChanges();

                // Присваиваем детей родителям
                parentDevice1.ChildDevices.Add(childDevice1);
                parentDevice1.ChildDevices.Add(childDevice2);
                parentDevice2.ChildDevices.Add(childDevice3);
                parentDevice2.ChildDevices.Add(childDevice4);
                parentDevice2.ChildDevices.Add(childDevice5);
                context.SaveChanges();

                // Создаем задачи
                var workItem1 = new WorkItem()
                                    {
                                        ChildDevice = childDevice1,
                                        ParentDevice = childDevice1.ParentDevice,
                                        DateTimeItemCreated = DateTime.UtcNow.AddDays(-3),
                                        Name = "Помыть посуду",
                                        Description = "Очень хорошо помыть посуду и вытереть после стол от воды.",
                                        Photos = new List<Photo>(),
                                        Comments = new List<Comment>()
                                    };
                var workItem2 = new WorkItem()
                                    {
                                        ChildDevice = childDevice2,
                                        ParentDevice = childDevice1.ParentDevice,
                                        DateTimeItemCreated = DateTime.UtcNow.AddDays(-3),
                                        Name = "Помыть посуду",
                                        Description = "Очень хорошо помыть посуду и вытереть после стол от воды.",
                                        Photos = new List<Photo>(),
                                        Comments = new List<Comment>()
                                    };
                var workItem3 = new WorkItem()
                                    {
                                        ChildDevice = childDevice3,
                                        ParentDevice = childDevice1.ParentDevice,
                                        DateTimeItemCreated = DateTime.UtcNow.AddDays(-3),
                                        Name = "Помыть посуду",
                                        Description = "Очень хорошо помыть посуду и вытереть после стол от воды.",
                                        Photos = new List<Photo>(),
                                        Comments = new List<Comment>()
                                    };
                var workItem4 = new WorkItem()
                                    {
                                        ChildDevice = childDevice1,
                                        ParentDevice = childDevice1.ParentDevice,
                                        DateTimeItemCreated = DateTime.UtcNow.AddDays(-2),
                                        Name = "Помыть посуду",
                                        Description = "Очень хорошо помыть посуду и вытереть после стол от воды.",
                                        Photos = new List<Photo>(),
                                        Comments = new List<Comment>()
                                    };
                var workItem5 = new WorkItem()
                                    {
                                        ChildDevice = childDevice2,
                                        ParentDevice = childDevice1.ParentDevice,
                                        DateTimeItemCreated = DateTime.UtcNow.AddDays(-2),
                                        Name = "Помыть посуду",
                                        Description = "Очень хорошо помыть посуду и вытереть после стол от воды.",
                                        Photos = new List<Photo>(),
                                        Comments = new List<Comment>()
                                    };
                var workItem6 = new WorkItem()
                                    {
                                        ChildDevice = childDevice3,
                                        ParentDevice = childDevice1.ParentDevice,
                                        DateTimeItemCreated = DateTime.UtcNow.AddDays(-2),
                                        Name = "Помыть посуду",
                                        Description = "Очень хорошо помыть посуду и вытереть после стол от воды.",
                                        Photos = new List<Photo>(),
                                        Comments = new List<Comment>()
                                    };
                var workItem7 = new WorkItem() { ChildDevice = childDevice1, ParentDevice = childDevice1.ParentDevice, DateTimeItemCreated = DateTime.UtcNow.AddDays(-1), Name = "Помыть пол", Description = "Очень хорошо помыть пол.", Photos = new List<Photo>(), Comments = new List<Comment>() };
                var workItem8 = new WorkItem() { ChildDevice = childDevice2, ParentDevice = childDevice1.ParentDevice, DateTimeItemCreated = DateTime.UtcNow.AddDays(-1), Name = "Помыть пол", Description = "Очень хорошо помыть пол.", Photos = new List<Photo>(), Comments = new List<Comment>() };
                var workItem9 = new WorkItem()
                                    {
                                        ChildDevice = childDevice1,
                                        ParentDevice = childDevice1.ParentDevice,
                                        DateTimeItemCreated = DateTime.UtcNow.AddDays(-3),
                                        Name = "Протереть столы",
                                        Description = "Очень хорошо протереть столы.",
                                        Photos = new List<Photo>(),
                                        Comments = new List<Comment>()
                                    };
                var workItem10 = new WorkItem()
                                     {
                                         ChildDevice = childDevice4,
                                         ParentDevice = childDevice1.ParentDevice,
                                         DateTimeItemCreated = DateTime.UtcNow.AddDays(-3),
                                         Name = "Помыть посуду",
                                         Description = "Очень хорошо помыть посуду и вытереть после стол от воды.",
                                         Photos = new List<Photo>(),
                                         Comments = new List<Comment>()
                                     };

                context.WorkItems.Add(workItem1);
                context.WorkItems.Add(workItem2);
                context.WorkItems.Add(workItem3);
                context.WorkItems.Add(workItem4);
                context.WorkItems.Add(workItem5);
                context.WorkItems.Add(workItem6);
                context.WorkItems.Add(workItem7);
                context.WorkItems.Add(workItem8);
                context.WorkItems.Add(workItem9);
                context.WorkItems.Add(workItem10);
                context.SaveChanges();

                // Создаем фотографии
                var photoData1 = new PhotoData() { Data = Images.img1 };
                var photoData2 = new PhotoData() { Data = Images.img2 };
                var photoData3 = new PhotoData() { Data = Images.img3 };
                var photoData4 = new PhotoData() { Data = Images.img4 };
                var photoData5 = new PhotoData() { Data = Images.img5 };
                var photoData6 = new PhotoData() { Data = Images.img6 };
                var photoData7 = new PhotoData() { Data = Images.img7 };
                var photoData8 = new PhotoData() { Data = Images.img8 };
                var photoData9 = new PhotoData() { Data = Images.img9 };

                var photo1 = new Photo() { PhotoData = photoData1 };
                var photo2 = new Photo() { PhotoData = photoData2 };
                var photo3 = new Photo() { PhotoData = photoData3 };
                var photo4 = new Photo() { PhotoData = photoData4 };
                var photo5 = new Photo() { PhotoData = photoData5 };
                var photo6 = new Photo() { PhotoData = photoData6 };
                var photo7 = new Photo() { PhotoData = photoData7 };
                var photo8 = new Photo() { PhotoData = photoData8 };
                var photo9 = new Photo() { PhotoData = photoData9 };

                context.PhotoDatas.Add(photoData1);
                context.PhotoDatas.Add(photoData2);
                context.PhotoDatas.Add(photoData3);
                context.PhotoDatas.Add(photoData4);
                context.PhotoDatas.Add(photoData5);
                context.PhotoDatas.Add(photoData6);
                context.PhotoDatas.Add(photoData7);
                context.PhotoDatas.Add(photoData8);
                context.PhotoDatas.Add(photoData9);
                context.SaveChanges();

                context.Photos.Add(photo1);
                context.Photos.Add(photo2);
                context.Photos.Add(photo3);
                context.Photos.Add(photo4);
                context.Photos.Add(photo5);
                context.Photos.Add(photo6);
                context.Photos.Add(photo7);
                context.Photos.Add(photo8);
                context.Photos.Add(photo9);
                context.SaveChanges();

                // Меняем статус задачам
                workItem1.DateTimeItemCompleted = DateTime.UtcNow.AddDays(-3).AddHours(8);
                workItem2.DateTimeItemCompleted = DateTime.UtcNow.AddDays(-3).AddHours(8);
                workItem3.DateTimeItemCompleted = DateTime.UtcNow.AddDays(-3).AddHours(8);
                workItem1.Photos.Add(photo1);
                workItem2.Photos.Add(photo2);
                workItem3.Photos.Add(photo3);
                workItem1.DateTimeItemCompleteConfirmed = DateTime.UtcNow.AddDays(-3).AddHours(8).AddMinutes(30);
                workItem2.DateTimeItemCompleteConfirmed = DateTime.UtcNow.AddDays(-3).AddHours(8).AddMinutes(30);
                workItem3.DateTimeItemCompleteConfirmed = DateTime.UtcNow.AddDays(-3).AddHours(8).AddMinutes(30);

                workItem4.DateTimeItemCompleted = DateTime.UtcNow.AddDays(-3).AddHours(8);
                workItem5.DateTimeItemCompleted = DateTime.UtcNow.AddDays(-3).AddHours(8);
                workItem6.DateTimeItemCompleted = DateTime.UtcNow.AddDays(-3).AddHours(8);
                workItem4.Photos.Add(photo4);
                workItem5.Photos.Add(photo5);
                workItem6.Photos.Add(photo6);

                // Создаем комментарии
                var comment1 = new Comment() { DateTimeCreated = DateTime.UtcNow.AddDays(-3).AddHours(8).AddMinutes(30), Message = "Плохо, делайте снова.", SenderDevice = workItem4.ParentDevice, Photos = new List<Photo>() };
                var comment2 = new Comment() { DateTimeCreated = DateTime.UtcNow.AddDays(-3).AddHours(8).AddMinutes(30), Message = "Плохо, делайте снова.", SenderDevice = workItem5.ParentDevice, Photos = new List<Photo>() };
                var comment3 = new Comment() { DateTimeCreated = DateTime.UtcNow.AddDays(-3).AddHours(8).AddMinutes(30), Message = "Плохо, делайте снова.", SenderDevice = workItem6.ParentDevice, Photos = new List<Photo>() };
                context.Comments.Add(comment1);
                context.Comments.Add(comment2);
                context.Comments.Add(comment3);
                context.SaveChanges();

                comment1.Photos.Add(photo7);
                comment2.Photos.Add(photo8);
                comment3.Photos.Add(photo9);
                context.SaveChanges();

                workItem4.Comments.Add(comment1);
                workItem5.Comments.Add(comment2);
                workItem6.Comments.Add(comment3);

                context.SaveChanges();
                transaction.Complete();
            }
        }
    }
}