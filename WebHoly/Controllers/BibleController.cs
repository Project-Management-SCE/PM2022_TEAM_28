using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHoly.Data;
using WebHoly.Models;

namespace WebHoly.Controllers
{
    public class BibleController : Controller
    {
        private readonly ApplicationDbContext _context;
        private Controllers.ApiController _apiController;

        public BibleController(ApplicationDbContext context, ApiController apiController)
        {
            _context = context;
            _apiController = apiController;

        }

        public IActionResult Index()
        {
            List<BookType> bookTypeList = new List<BookType>();

            bookTypeList = _context.BookTypes.ToList();

            bookTypeList.Insert(0, new BookType { Id = 0, Name = "בחר" });

            ViewBag.ListofBookType = bookTypeList;
            return View();
        }
        [HttpPost]
        public async Task<JsonResult> IndexAsync(BookType objbookType)
        {
            if (objbookType.Id == 0)
            {
                ModelState.AddModelError("", "בחר קטגוריה");
            }
            else if (objbookType.BookId == 0)
            {
                ModelState.AddModelError("", "בחר ספר");
            }
            else if (objbookType.EpisodeId == 0)
            {
                ModelState.AddModelError("", "בחר פרק");
            }
            var bookName = _context.Books.Find(objbookType.BookId).SubName;
            var episodeNumber = _context.Episodes.Find(objbookType.EpisodeId).Number;

            var item = await _apiController.BibleApichapter(episodeNumber, bookName);

            return Json(new { Success = true, Item = item });
        }

        public JsonResult GetBook(int BookTypeId)
        {
            List<Book> bookList = new List<Book>();

            bookList = _context.Books.Where(x => x.BookTypeId == BookTypeId).ToList();
            bookList.Insert(0, new Book { Id = 0, Name = "בחר" });

            return Json(new SelectList(bookList, "Id", "Name"));
        }

        public JsonResult GetEpisode(int BookId)
        {
            List<Episode> bookList = new List<Episode>();

            bookList = _context.Episodes.Where(x => x.BookId == BookId).ToList();
            bookList.Insert(0, new Episode { Id = 0, Number = 0 });

            return Json(new SelectList(bookList, "Id", "Number"));
        }

        //public void AddBooksType()
        //{
        //    List<BookType> booksType = new List<BookType>()
        //    {
        //        new BookType
        //        {
        //            Name = "תורה",
        //            Type = "חמישה חומשי תודה"
        //        },
        //        new BookType
        //        {
        //            Name = "נביאים",
        //            Type = "שמונה ספרים"
        //        },
        //        new BookType
        //        {
        //            Name = "כתובים",
        //            Type = "אחד עשר ספרים"
        //        }
        //    };
        //    _context.AddRange(booksType);
        //    _context.SaveChanges();
        //}


        //public void AddBooks()
        //{
        //    List<Book> books = new List<Book>()
        //    {
        //        new Book
        //        {
        //            Name = "בְּרֵאשִׁית",
        //            SubName = "ge",
        //            BookTypeId = 1
        //        },
        //        new Book
        //        {
        //            Name = "שְׁמוֹת",
        //            SubName = "exo",
        //            BookTypeId = 1
        //        },
        //        new Book
        //        {
        //             Name = "וַיִּקְרָא",
        //            SubName = "lev",
        //            BookTypeId = 1
        //        },
        //        new Book
        //        {
        //             Name = "בְּמִדְבַּר",
        //            SubName = "num",
        //            BookTypeId = 1
        //        },
        //        new Book
        //        {
        //             Name = "דברים",
        //            SubName = "deu",
        //            BookTypeId = 1
        //        },
        //        new Book
        //        {
        //             Name = "יְהוֹשֻׁעַ",
        //            SubName = "josh",
        //            BookTypeId = 2
        //        },
        //        new Book
        //        {
        //             Name = "שופטים",
        //            SubName = "jdgs",
        //            BookTypeId = 2
        //        },
        //        new Book
        //        {
        //             Name = "שְׁמוּאֵל א",
        //            SubName = "1sm",
        //            BookTypeId = 2
        //        },
        //         new Book
        //        {
        //             Name = " שְׁמוּאֵל ב",
        //            SubName = "2sm",
        //            BookTypeId = 2
        //        },
        //        new Book
        //        {
        //             Name = " מְלָכִים א",
        //            SubName = "1ki",
        //            BookTypeId = 2
        //        }, 
        //        new Book
        //        {
        //             Name = "מְלָכִים ב",
        //            SubName = "2ki",
        //            BookTypeId = 2
        //        },
        //        new Book
        //        {
        //             Name = "יְשַׁעְיָהוּ",
        //            SubName = "isa",
        //            BookTypeId = 2
        //        },
        //        new Book
        //        {
        //             Name = "יִרְמְיָהוּ",
        //            SubName = "jer",
        //            BookTypeId = 2
        //        },
        //        new Book
        //        {
        //             Name = "יְחֶזְקֵאל",
        //            SubName = "eze",
        //            BookTypeId = 2
        //        },
        //        new Book
        //        {
        //             Name = "הוֹשֵׁעַ",
        //            SubName = "hos",
        //            BookTypeId = 2
        //        },
        //        new Book
        //        {
        //             Name = "יוֹאֵל",
        //            SubName = "joel",
        //            BookTypeId = 2
        //        },
        //        new Book
        //        {
        //             Name = "עָמוֹס",
        //            SubName = "amos",
        //            BookTypeId = 2
        //        },
        //        new Book
        //        {
        //             Name = "עֹבַדְיָה",
        //            SubName = "obad",
        //            BookTypeId = 2
        //        },
        //        new Book
        //        {
        //             Name = "יוֹנָה",
        //            SubName = "jonah",
        //            BookTypeId = 2
        //        },
        //        new Book
        //        {
        //             Name = "מִיכָה",
        //            SubName = "mic",
        //            BookTypeId = 2
        //        },
        //        new Book
        //        {
        //             Name = "נַחוּם",
        //            SubName = "nahum",
        //            BookTypeId = 2
        //        },
        //        new Book
        //        {
        //             Name = "חֲבַקּוּק",
        //            SubName = "hab",
        //            BookTypeId = 2
        //        },
        //        new Book
        //        {
        //             Name = "צְפַנְיָה",
        //            SubName = "zep",
        //            BookTypeId = 2
        //        },
        //        new Book
        //        {
        //             Name = "חַגַּי",
        //            SubName = "heg",
        //            BookTypeId = 2
        //        },
        //        new Book
        //        {
        //             Name = "זְכַרְיָה",
        //            SubName = "zec",
        //            BookTypeId = 2
        //        },
        //        new Book
        //        {
        //             Name = "מַלְאָכִי",
        //            SubName = "mal",
        //            BookTypeId = 2
        //        },
        //        new Book
        //        {
        //             Name = "דִּבְרֵי הַיָּמִים א",
        //            SubName = "1chr",
        //            BookTypeId = 3
        //        },
        //        new Book
        //        {
        //             Name = "דִּבְרֵי הַיָּמִים ב",
        //            SubName = "2chr",
        //            BookTypeId = 3
        //        },
        //        new Book
        //        {
        //             Name = "תְּהִלִּים",
        //            SubName = "psa",
        //            BookTypeId = 3
        //        },
        //        new Book
        //        {
        //             Name = "אִיּוֹב",
        //            SubName = "job",
        //            BookTypeId = 3
        //        },
        //        new Book
        //        {
        //             Name = "מִשְׁלֵי",
        //            SubName = "prv",
        //            BookTypeId = 3
        //        },
        //        new Book
        //        {
        //             Name = "רוּת",
        //            SubName = "ruth",
        //            BookTypeId = 3
        //        },
        //        new Book
        //        {
        //             Name = "שִׁיר הַשִּׁירִים",
        //            SubName = "ssol",
        //            BookTypeId = 3
        //        },
        //        new Book
        //        {
        //             Name = "קֹהֶלֶת",
        //            SubName = "eccl",
        //            BookTypeId = 3
        //        },
        //        new Book
        //        {
        //             Name = "אֵיכָה",
        //            SubName = "lam",
        //            BookTypeId = 3
        //        },
        //        new Book
        //        {
        //             Name = "אֶסְתֵּר",
        //            SubName = "est",
        //            BookTypeId = 3
        //        },
        //        new Book
        //        {
        //             Name = "דָּנִיֵּאל",
        //            SubName = "dan",
        //            BookTypeId = 3
        //        },
        //        new Book
        //        {
        //             Name = "עֶזְרָא",
        //            SubName = "ezra",
        //            BookTypeId = 3
        //        },
        //        new Book
        //        {
        //             Name = "נְחֶמְיָה",
        //            SubName = "neh",
        //            BookTypeId = 3
        //        }
        //    };
        //    _context.AddRange(books);
        //    _context.SaveChanges();
        //}

        //public async Task AddEpisode()
        //{
        //    //בראשית
        //    for (int i = 1; i < 51; i++)
        //    {
        //        Episode episode = new Episode()
        //        {
        //            Number = i,
        //            BookId = 1
        //        };
        //       await _context.AddAsync(episode);
        //        await _context.SaveChangesAsync();

        //    }
        //    //שמות
        //    for (int i = 1; i < 41; i++)
        //    {
        //        Episode episode = new Episode()
        //        {
        //            Number = i,
        //            BookId = 22
        //        };
        //        await _context.AddAsync(episode);
        //        await _context.SaveChangesAsync();
        //    }
        //    //ויקרא
        //    for (int i = 1; i < 28; i++)
        //    {
        //        Episode episode = new Episode()
        //        {
        //            Number = i,
        //            BookId = 23
        //        };
        //        await _context.AddAsync(episode);
        //        await _context.SaveChangesAsync();
        //    }
        //    //במדבר
        //    for (int i = 1; i < 37; i++)
        //    {
        //        Episode episode = new Episode()
        //        {
        //            Number = i,
        //            BookId = 24
        //        };
        //        await _context.AddAsync(episode);
        //        await _context.SaveChangesAsync();
        //    }
        //    //דברים
        //    for (int i = 1; i < 35; i++)
        //    {
        //        Episode episode = new Episode()
        //        {
        //            Number = i,
        //            BookId = 25
        //        };
        //        await _context.AddAsync(episode);
        //        await _context.SaveChangesAsync();
        //    }
        //    //יהושע
        //    for (int i = 1; i < 25; i++)
        //    {
        //        Episode episode = new Episode()
        //        {
        //            Number = i,
        //            BookId = 26
        //        };
        //        await _context.AddAsync(episode);
        //        await _context.SaveChangesAsync();
        //    }
        //    //שופטים
        //    for (int i = 1; i < 22; i++)
        //    {
        //        Episode episode = new Episode()
        //        {
        //            Number = i,
        //            BookId = 27
        //        };
        //        await _context.AddAsync(episode);
        //        await _context.SaveChangesAsync();
        //    }
        //    //שמואל א
        //    for (int i = 1; i < 32; i++)
        //    {
        //        Episode episode = new Episode()
        //        {
        //            Number = i,
        //            BookId = 28
        //        };
        //        await _context.AddAsync(episode);
        //        await _context.SaveChangesAsync();
        //    }
        //    //שמואל ב
        //    for (int i = 1; i < 25; i++)
        //    {
        //        Episode episode = new Episode()
        //        {
        //            Number = i,
        //            BookId = 30
        //        };
        //        await _context.AddAsync(episode);
        //        await _context.SaveChangesAsync();
        //    }
        //    //רות
        //    for (int i = 1; i < 5; i++)
        //    {
        //        Episode episode = new Episode()
        //        {
        //            Number = i,
        //            BookId = 12
        //        };
        //        await _context.AddAsync(episode);
        //        await _context.SaveChangesAsync();
        //    }
        //    //מלכים א
        //    for (int i = 1; i < 23; i++)
        //    {
        //        Episode episode = new Episode()
        //        {
        //            Number = i,
        //            BookId = 38
        //        };
        //        await _context.AddAsync(episode);
        //        await _context.SaveChangesAsync();
        //    }
        //    //מלכים ב
        //    for (int i = 1; i < 26; i++)
        //    {
        //        Episode episode = new Episode()
        //        {
        //            Number = i,
        //            BookId = 31
        //        };
        //        await _context.AddAsync(episode);
        //        await _context.SaveChangesAsync();
        //    }
        //    //דברי הימים א
        //    for (int i = 1; i < 30; i++)
        //    {
        //        Episode episode = new Episode()
        //        {
        //            Number = i,
        //            BookId = 7
        //        };
        //        await _context.AddAsync(episode);
        //        await _context.SaveChangesAsync();
        //    }
        //    //דברי הימים ב
        //    for (int i = 1; i < 37; i++)
        //    {
        //        Episode episode = new Episode()
        //        {
        //            Number = i,
        //            BookId = 8
        //        };
        //        await _context.AddAsync(episode);
        //        await _context.SaveChangesAsync();
        //    }
        //    //עזרא
        //    for (int i = 1; i < 11; i++)
        //    {
        //        Episode episode = new Episode()
        //        {
        //            Number = i,
        //            BookId = 19
        //        };
        //        await _context.AddAsync(episode);
        //        await _context.SaveChangesAsync();
        //    }
        //    //נחמיה
        //    for (int i = 1; i < 14; i++)
        //    {
        //        Episode episode = new Episode()
        //        {
        //            Number = i,
        //            BookId = 39
        //        };
        //        await _context.AddAsync(episode);
        //        await _context.SaveChangesAsync();
        //    }
        //    //אסתר
        //    for (int i = 1; i < 11; i++)
        //    {
        //        Episode episode = new Episode()
        //        {
        //            Number = i,
        //            BookId = 16
        //        };
        //        await _context.AddAsync(episode);
        //        await _context.SaveChangesAsync();
        //    }
        //    //איוב
        //    for (int i = 1; i < 43; i++)
        //    {
        //        Episode episode = new Episode()
        //        {
        //            Number = i,
        //            BookId = 18
        //        };
        //        await _context.AddAsync(episode);
        //        await _context.SaveChangesAsync();
        //    }
        //    //תהלים
        //    for (int i = 1; i < 151; i++)
        //    {
        //        Episode episode = new Episode()
        //        {
        //            Number = i,
        //            BookId = 10
        //        };
        //        await _context.AddAsync(episode);
        //        await _context.SaveChangesAsync();
        //    }
        //    //משלי
        //    for (int i = 1; i < 32; i++)
        //    {
        //        Episode episode = new Episode()
        //        {
        //            Number = i,
        //            BookId = 11
        //        };
        //        await _context.AddAsync(episode);
        //        await _context.SaveChangesAsync();
        //    }
        //    //קוהלת
        //    for (int i = 1; i < 13; i++)
        //    {
        //        Episode episode = new Episode()
        //        {
        //            Number = i,
        //            BookId = 14
        //        };
        //        await _context.AddAsync(episode);
        //        await _context.SaveChangesAsync();
        //    }
        //    //שיר השירים
        //    for (int i = 1; i < 9; i++)
        //    {
        //        Episode episode = new Episode()
        //        {
        //            Number = i,
        //            BookId = 13
        //        };
        //        await _context.AddAsync(episode);
        //        await _context.SaveChangesAsync();
        //    }
        //    //ישעיהו
        //    for (int i = 1; i < 67; i++)
        //    {
        //        Episode episode = new Episode()
        //        {
        //            Number = i,
        //            BookId = 32
        //        };
        //        await _context.AddAsync(episode);
        //        await _context.SaveChangesAsync();
        //    }
        //    //ירמיהו
        //    for (int i = 1; i < 53; i++)
        //    {
        //        Episode episode = new Episode()
        //        {
        //            Number = i,
        //            BookId = 33
        //        };
        //        await _context.AddAsync(episode);
        //        await _context.SaveChangesAsync();
        //    }
        //    //איכה
        //    for (int i = 1; i < 6; i++)
        //    {
        //        Episode episode = new Episode()
        //        {
        //            Number = i,
        //            BookId = 15
        //        };
        //        await _context.AddAsync(episode);
        //        await _context.SaveChangesAsync();
        //    }
        //    //יחזקאל
        //    for (int i = 1; i < 49; i++)
        //    {
        //        Episode episode = new Episode()
        //        {
        //            Number = i,
        //            BookId = 34
        //        };
        //        await _context.AddAsync(episode);
        //        await _context.SaveChangesAsync();
        //    }
        //    //דניאל
        //    for (int i = 1; i < 13; i++)
        //    {
        //        Episode episode = new Episode()
        //        {
        //            Number = i,
        //            BookId = 17
        //        };
        //        await _context.AddAsync(episode);
        //        await _context.SaveChangesAsync();
        //    }
        //    //הושע
        //    for (int i = 1; i < 15; i++)
        //    {
        //        Episode episode = new Episode()
        //        {
        //            Number = i,
        //            BookId = 35
        //        };
        //        await _context.AddAsync(episode);
        //        await _context.SaveChangesAsync();
        //    }
        //    //יואל
        //    for (int i = 1; i < 4; i++)
        //    {
        //        Episode episode = new Episode()
        //        {
        //            Number = i,
        //            BookId = 36
        //        };
        //        await _context.AddAsync(episode);
        //        await _context.SaveChangesAsync();
        //    }
        //    //עמוס
        //    for (int i = 1; i < 10; i++)
        //    {
        //        Episode episode = new Episode()
        //        {
        //            Number = i,
        //            BookId = 37
        //        };
        //        await _context.AddAsync(episode);
        //        await _context.SaveChangesAsync();
        //    }
        //    //עובדיה
        //    for (int i = 1; i < 2; i++)
        //    {
        //        Episode episode = new Episode()
        //        {
        //            Number = i,
        //            BookId = 21
        //        };
        //        await _context.AddAsync(episode);
        //        await _context.SaveChangesAsync();
        //    }
        //    //יונה
        //    for (int i = 1; i < 5; i++)
        //    {
        //        Episode episode = new Episode()
        //        {
        //            Number = i,
        //            BookId = 29
        //        };
        //        await _context.AddAsync(episode);
        //        await _context.SaveChangesAsync();
        //    }
        //    //מיכה
        //    for (int i = 1; i < 8; i++)
        //    {
        //        Episode episode = new Episode()
        //        {
        //            Number = i,
        //            BookId = 20
        //        };
        //        await _context.AddAsync(episode);
        //        await _context.SaveChangesAsync();
        //    }
        //    //נחום
        //    for (int i = 1; i < 4; i++)
        //    {
        //        Episode episode = new Episode()
        //        {
        //            Number = i,
        //            BookId = 9
        //        };
        //        await _context.AddAsync(episode);
        //        await _context.SaveChangesAsync();
        //    }
        //    //חבקוק
        //    for (int i = 1; i < 4; i++)
        //    {
        //        Episode episode = new Episode()
        //        {
        //            Number = i,
        //            BookId = 2
        //        };
        //        await _context.AddAsync(episode);
        //        await _context.SaveChangesAsync();
        //    }
        //    //צפניה
        //    for (int i = 1; i < 4; i++)
        //    {
        //        Episode episode = new Episode()
        //        {
        //            Number = i,
        //            BookId = 3
        //        };
        //        await _context.AddAsync(episode);
        //        await _context.SaveChangesAsync();
        //    }
        //    //חגי
        //    for (int i = 1; i < 3; i++)
        //    {
        //        Episode episode = new Episode()
        //        {
        //            Number = i,
        //            BookId = 4
        //        };
        //        await _context.AddAsync(episode);
        //        await _context.SaveChangesAsync();
        //    }
        //    //זכריה
        //    for (int i = 1; i < 15; i++)
        //    {
        //        Episode episode = new Episode()
        //        {
        //            Number = i,
        //            BookId = 5
        //        };
        //        await _context.AddAsync(episode);
        //        await _context.SaveChangesAsync();
        //    }
        //    //מלאכי
        //    for (int i = 1; i < 4; i++)
        //    {
        //        Episode episode = new Episode()
        //        {
        //            Number = i,
        //            BookId = 6
        //        };
        //        await _context.AddAsync(episode);
        //        await _context.SaveChangesAsync();
        //    }
        //}
    }
}
