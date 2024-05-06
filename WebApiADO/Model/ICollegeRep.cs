namespace WebApiADO.Model
{
    public interface ICollegeRep
    {
        public List<College> GetColleges();
        public List<College> GetCollegeById(int id);
        public void AddCollege(College college);
        public void UpdateCollege(int id, College college);
        public void DeleteCollege(int id);
    }
}
