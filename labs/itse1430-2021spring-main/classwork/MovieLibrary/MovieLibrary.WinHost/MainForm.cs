using System;
using System.Linq;
using System.Windows.Forms;

namespace MovieLibrary.WinHost
{
    public partial class MainForm : Form
    {
        #region Construction

        public MainForm ()
        {
            InitializeComponent();                            
        }
        #endregion

        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad(e);

            var movies = _database.GetAll();
            if (movies.Count() == 0)
            {
                if (MessageBox.Show(this, "Do you want to seed the database?", "Seed Database", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //var seed = new SeedDatabase();
                    //seed.Seed(_database);
                    //new SeedDatabase().Seed(_database);

                    //Can create an instance but no instance members so useless
                    //var seed = new SeedDatabase();

                    //Calling static member requires the type
                    //SeedDatabase.Seed(_database);
                    _database.Seed();
                };
            };

            UpdateUI();
        }

        private void OnHelpAbout ( object sender, EventArgs e )
        {
            //MessageBox.Show("Help - About");
            var form = new AboutBox();

            //Show the form modally
            form.ShowDialog();
            //form.Show(); //modeless
        }

        private void OnFileExit ( object sender, EventArgs e )
        {
            //Display a confirmation and quit if yes
            var result = MessageBox.Show(this, "Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
                return;

            //Close the form
            Close();
        }

        // try-catch block - handles exception
        //   try-catch-statement ::= try-block catch-block+
        //   try-block ::= try { S* }
        //   catch-block ::= catch [catch-type] { S* }
        //   catch-type ::= ( T id )
        //   Executes all code inside try-block
        //     If anything throws an exception, stops execution of remainder of try block
        //     Jumps to catch block looking for handler (error handling mode)
        private void OnMovieAdd ( object sender, EventArgs e )
        {
            var form = new MovieDetailForm();

            do
            {
                if (form.ShowDialog(this) == DialogResult.Cancel)
                    return;

                try
                {
                    //Save the movie
                    _database.Add(form.Movie);

                    //Only gets here if it works
                    break;
                } catch (ArgumentException ex)
                {
                    DisplayError("Add Failed", "You didn't pass the args right");
                } catch (Exception ex)
                {
                    //Error handling
                    DisplayError("Add Failed", ex.Message);
                };                
            } while (true);

            UpdateUI();
        }

        private void DisplayError ( string title, string message )
        {
            MessageBox.Show(this, message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void OnMovieDelete ( object sender, EventArgs e )
        {
            //If a movie exists then display confirmation and delete
            var movie = GetSelectedMovie();
            if (movie == null)
                return;

            var result = MessageBox.Show(this, $"Are you sure you want to delete '{movie.Title}'?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
                return;

            try
            {
                _database.Delete(movie.Id);
            } catch (Exception ex)
            {
                DisplayError("Delete Failed", ex.Message);
            };

            UpdateUI();
        }
                
        // Standard event signature - object, EventArgs (or derived)
        private void OnMovieEdit ( object sender, EventArgs e )
        {
            //If a movie exists then display confirmation and delete
            var movie = GetSelectedMovie();
            if (movie == null)
                return;

            var form = new MovieDetailForm();
            form.Movie = movie;

            do
            {
                if (form.ShowDialog(this) == DialogResult.Cancel)
                    return;

                //Save the movie
                try
                {
                    _database.Update(movie.Id, form.Movie);
                    break;
                } catch (Exception ex)
                {
                    DisplayError("Add Failed", ex.Message);
                };
            } while (true);

            UpdateUI();
        }

        #region Private Members

        private Movie GetSelectedMovie ()
        {
            // Enumerable has 2 type conversion methods
            //   OfType<S> () -> takes IEnumerable<T> and returns IEnumerable<S> for each T that is an S
            //   Cast<S> () -> takes IEnumerable<T> and casts each item to S, throwing an exception if any fail

            //Cast SelectedItem as Movie
            //lstMovies.SelectedItems.OfType<Movie>();  // IEnumerable<Movie> item as T
            //lstMovies.SelectedItems.Cast<Movie>();   // IEnumerable<Movie> (S)item

            return lstMovies.SelectedItem as Movie;
        }

        private void UpdateUI ()
        {
            lstMovies.DisplayMember = "Title";

            try
            {
                // Enumerable has 2 conversion methods
                //     ToArray () -> IEnumerable<T> to T[]
                //     ToList () -> IEnumerable<T> to List<T>
                // Notes:
                //    1. They trigger a full enumeration of the entire items
                //    2. No further deferred execution
                //    3. Besides actually needing an array or list it is useful when you must ensure IEnumerable<T> code has fully executed
                var movies = _database.GetAll();

                //Can bind listbox using Items or DataSource            
                lstMovies.DataSource = movies.ToArray();                
            } catch (Exception e)
            {
                DisplayError("Error retrieving movies", e.Message);

                lstMovies.DataSource = new Movie[0];
            };                                         
        }

        private readonly IMovieDatabase _database = new IO.FileMovieDatabase("movies.csv");

        #endregion
    }
}
