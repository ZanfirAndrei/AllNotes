using AllNotes.Domain.EF.AllNotesContext;
using AllNotes.Domain.EF.IRepositories;
using AllNotes.Domain.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllNotes.Domain.EF.Wrapper
{
    public class WrapperRepository : IWrapperRepository
    {
        private AllNotesDbContext _appContext;
        private ICheckBoxRepository _checkBox;
        private ICheckListRepository _checkList;
        private INoteRepository _note;
        private ICategoryRepository _category;
        private ISeriesRepository _series;
        private IExerciseRepository _exercise;
        private IScheduleRepository _schedule;



        public ICheckBoxRepository CheckBox
        {
            get
            {
                if (_checkBox == null)
                {
                    _checkBox = new CheckBoxRepository(_appContext);
                }

                return _checkBox;
            }
        }

        public ICheckListRepository CheckList
        {
            get
            {
                if (_checkList == null)
                {
                    _checkList = new CheckListRepository(_appContext);
                }

                return _checkList;
            }
        }

        public INoteRepository Note
    {
            get
            {
                if (_note == null)
                {
                    _note = new NoteRepository(_appContext);
                }

                return _note;
            }
        }

        public ICategoryRepository Category
{
            get
            {
                if (_category == null)
                {
                    _category = new CategoryRepository(_appContext);
                }

                return _category;
            }
        }

        public ISeriesRepository Series
{
            get
            {
                if (_series == null)
                {
                    _series = new SeriesRepository(_appContext);
                }

                return _series;
            }
        }

        public IExerciseRepository Exercise
{
            get
            {
                if (_exercise == null)
                {
                    _exercise = new ExerciseRepository(_appContext);
                }

                return _exercise;
            }
        }

        public IScheduleRepository Schedule
{
            get
            {
                if (_schedule == null)
                {
                    _schedule = new ScheduleRepository(_appContext);
                }

                return _schedule;
            }
        }

        

        public WrapperRepository(AllNotesDbContext appContext)
        {
            _appContext = appContext;
        }

        public void CommitChanges()
        {
            _appContext.SaveChanges();
        }
    }
}

