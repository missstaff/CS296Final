using StephenKingFanSite.Controllers;
using StephenKingFanSite.Models;
using StephenKingFanSite.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace KingTests
{
    public class NovelsControllerTest
    {
        DateTime dt = new DateTime(2021, 01, 01);

        [Fact]
        public void GetAllNovels()
        {
            var repo = new FakeNovelRepo();
            var controller = new NovelsController(repo);
            repo.Novels.Add(new Novel()
            {
                Title = "test",
                Publisher = "test",
                PulicationDate = dt,
                Genre = "H",
                Rating = 5
            });
            repo.Novels.Add(new Novel()
            {
                Title = "test2",
                Publisher = "test2",
                PulicationDate = dt,
                Genre = "S",
                Rating = 3
            });
            repo.Novels.Add(new Novel()
            {
                Title = "test3",
                Publisher = "test3",
                PulicationDate = dt,
                Genre = "T",
                Rating = 4
            });

            var novels = repo.Novels.ToList();
            Assert.Equal(3, novels.Count);
            Assert.Equal("test", novels[0].Title);
            Assert.Equal("test2", novels[1].Title);
            Assert.Equal("test3", novels[2].Title);
        }

        [Fact]
        public void GetANovel()
        {
            var repo = new FakeNovelRepo();
            var controller = new NovelsController(repo);
            repo.Novels.Add(new Novel()
            {
                ID = 1,
                Title = "test",
                Publisher = "test",
                PulicationDate = dt,
                Genre = "H",
                Rating = 5
            });
            repo.Novels.Add(new Novel()
            {
                ID = 2,
                Title = "test2",
                Publisher = "test2",
                PulicationDate = dt,
                Genre = "S",
                Rating = 3
            });
            repo.Novels.Add(new Novel()
            {
                ID = 3,
                Title = "test3",
                Publisher = "test3",
                PulicationDate = dt,
                Genre = "T",
                Rating = 4
            });

            var novels = repo.Novels.ToList();
            int id = 3;
            var novel = novels.Find(m => m.ID == id);
            Assert.Equal(3, novels.Count);
            Assert.Equal("test3", novel.Title);
            Assert.Equal("T", novel.Genre);
            Assert.Equal(4, novel.Rating);
        }

        [Fact]
        public void AddNovel()
        {
            var repo = new FakeNovelRepo();
            var controller = new NovelsController(repo);
            var novels = repo.Novels.ToList();
            var novel = new Novel()
            {
                Title = "test",
                Publisher = "test",
                PulicationDate = dt,
                Genre = "H",
                Rating = 5

            };
            novels.Add(novel);
            Assert.Equal("test", novels[0].Title);
        }

        [Fact]
        public void DeleteNovel()
        {
            var repo = new FakeNovelRepo();
            var controller = new NovelsController(repo);
            repo.Novels.Add(new Novel()
            {
                ID = 1,
                Title = "test",
                Publisher = "test",
                PulicationDate = dt,
                Genre = "H",
                Rating = 5
            });
            repo.Novels.Add(new Novel()
            {
                ID = 2,
                Title = "test2",
                Publisher = "test2",
                PulicationDate = dt,
                Genre = "S",
                Rating = 3
            });
            repo.Novels.Add(new Novel()
            {
                ID = 3,
                Title = "test3",
                Publisher = "test3",
                PulicationDate = dt,
                Genre = "T",
                Rating = 4
            });

            var novels = repo.Novels.ToList();
            int id = 1;
            var novel = novels.Find(m => m.ID == id);
            novels.Remove(novel);
            Assert.Equal(2, novels.Count);
            Assert.Equal("test2", novels[0].Title);
            Assert.Equal("test3", novels[1].Title);
        }

        [Fact]
        public void UpdateNovel()
        {
            var repo = new FakeNovelRepo();
            var controller = new NovelsController(repo);
            repo.Novels.Add(new Novel()
            {
                ID = 1,
                Title = "test",
                Publisher = "test",
                PulicationDate = dt,
                Genre = "H",
                Rating = 5
            });
            repo.Novels.Add(new Novel()
            {
                ID = 2,
                Title = "test2",
                Publisher = "test2",
                PulicationDate = dt,
                Genre = "S",
                Rating = 3
            });
            repo.Novels.Add(new Novel()
            {
                ID = 3,
                Title = "test3",
                Publisher = "test3",
                PulicationDate = dt,
                Genre = "T",
                Rating = 4
            });

            var novels = repo.Novels.ToList();
            int id = 2;
            var novel = novels.Find(m => m.ID == id);

            novel.Title = "Updated";
            novel.Publisher = "Updated";
            novel.Rating = 1;

            Assert.Equal(3, novels.Count);
            Assert.Equal("Updated", novel.Title);
            Assert.Equal("Updated", novel.Publisher);
            Assert.Equal(1, novel.Rating);
        }
    }
}
