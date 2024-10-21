using PortfoloAPI.Data.Entitites;

namespace PortfolioAPI.Data.Repositories
{
    public class ExperienceRepository
    {
        private readonly ApplicationContext _context;

        public ExperienceRepository(ApplicationContext context)
        {
            _context = context;
        }

        public List<Experience> Get()
        {
            return _context.Experiences.Where(e => e.State == "Active").ToList();
        }

        public List<Experience> GetAllExperiences()
        {
            return _context.Experiences.ToList();
        }
        public List<Experience> GetExperienceByTitle(string title)
        {
            return _context.Experiences.Where(e => e.Title.ToLower().Contains(title.ToLower())).ToList();
        }

        public int AddExperience(Experience experience)
        {
            _context.Experiences.Add(experience);
            _context.SaveChanges();
            return experience.Id;
        }

        public Experience? DeleteExperience(int id)
        {
            Experience? experienceToDelete = _context.Experiences.FirstOrDefault(e => e.Id == id);
            
            if(experienceToDelete is not null)
            {
                experienceToDelete.State = "Deleted";
                _context.SaveChanges();
            }

            return experienceToDelete;
        }
    }
}