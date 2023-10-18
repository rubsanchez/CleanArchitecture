using CleanArchitecture.Data;
using CleanArchitecture.Domain;
using Microsoft.EntityFrameworkCore;

StreamerDbContext dbContext = new();

//await AddNewRecords();
//QueryStreaming();
//await QueryFilter("Netf");
//await QueryLinq("a");
//await AddNewStreamerWithVideo();
//await AddNewVideoWithStreamerId();
//await AddNewActorWithVideo();
//await AddNewDirectorWithVideo();


async Task MultipleEntitiesQuery()
{
    var videoWithActors = await dbContext.Videos!
                            .Include(x => x.Actors)
                            .FirstOrDefaultAsync(x => x.Id == 1);
}

async Task AddNewDirectorWithVideo()
{
    Director director = new()
    {
        Name = "Christopher",
        Surname = "Nolan",
        VideoId = 4
    };

    await dbContext.AddAsync(director);
    await dbContext.SaveChangesAsync();
}

async Task AddNewActorWithVideo()
{
    Actor actor = new()
    {
        Name = "Christian",
        Surname = "Bale"
    };

    await dbContext.AddAsync(actor);
    await dbContext.SaveChangesAsync();

    VideoActor videoActor = new()
    {
        ActorId = actor.Id,
        VideoId = 4
    };

    await dbContext.AddAsync(videoActor);
    await dbContext.SaveChangesAsync();
}

async Task AddNewVideoWithStreamerId()
{
    Video darkNight = new()
    {
        Name = "The Dark Knight",
        StreamerId = 4,
    };

    await dbContext.AddAsync(darkNight);
    await dbContext.SaveChangesAsync();
}

async Task AddNewStreamerWithVideo()
{
    Streamer screen = new()
    {
        Name = "Screen"
    };

    Video hungerGames = new()
    {
        Name = "The Hunger Games",
        Streamer = screen,
    };

    await dbContext.AddAsync(hungerGames);
    await dbContext.SaveChangesAsync();
}

async Task TrackingAndNoTracking()
{
    var streamerWithTracking = await dbContext.Streamers!.FirstOrDefaultAsync(x => x.Id == 1);
    var streamerWithNoTracking = await dbContext.Streamers!.AsNoTracking().FirstOrDefaultAsync(x => x.Id == 2);

    streamerWithTracking.Name = "Netflix Premium";
    streamerWithNoTracking.Name = "Amazon Videos"; // No actualizará el record

    await dbContext.SaveChangesAsync();
}

async Task QueryLinq(string streamerNombre)
{
    var streamers = await (from s in dbContext.Streamers!
                           where EF.Functions.Like(s.Name, $"%{streamerNombre}%")
                           select s).ToListAsync();

    foreach (var streamer in streamers)
    {
        Console.WriteLine($"{streamer.Id} - {streamer.Name}");
    }
}

async Task QueryFilter(string name)
{
    //var streamers = await dbContext!.Streamers!.Where(x => x.Name.Contains(name)).ToListAsync();
    var streamers = await dbContext!.Streamers!.Where(x => EF.Functions.Like(x.Name, $"%{name}%")).ToListAsync();

    foreach (var streamer in streamers)
    {
        Console.WriteLine($"{streamer.Id} - {streamer.Name}");
    }
}

void QueryStreaming()
{
    var streamers = dbContext.Streamers!.ToList();

    foreach (var streamer in streamers)
    {
        Console.WriteLine($"{streamer.Id} - {streamer.Name}");
    }
}

async Task AddNewRecords()
{
    Streamer streamer = new()
    {
        Name = "Disney+",
        Url = "https://www.disneyplus.com"
    };

    dbContext!.Streamers!.Add(streamer);

    await dbContext.SaveChangesAsync();


    var movies = new List<Video>()
{
    new Video()
    {
        Name = "The Lion King",
        StreamerId = streamer.Id
    },
    new Video()
    {
        Name = "Moana",
        StreamerId = streamer.Id
    },
    new Video()
    {
        Name = "Elemental",
        StreamerId = streamer.Id
    }
};

    await dbContext.AddRangeAsync(movies);
    await dbContext.SaveChangesAsync();
}