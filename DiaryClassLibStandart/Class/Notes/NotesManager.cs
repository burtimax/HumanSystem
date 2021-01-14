using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace LibForPersonalTool.Class.Notes
{
    public class NotesManager
    {
        public delegate void ChangeCurrentNote(Note prevNote, Note curNote);
        public event ChangeCurrentNote CurrentNoteChanged;
        public NotifyCollectionChangedEventHandler NotesCollectionChangedHandler
        {
            set
            {
                this.Notes.CollectionChanged -= value;
                this.Notes.CollectionChanged += value;
            }
        }

        public ObservableCollection<Note> Notes;

        public Note CurrentNote;

        public NotesManager()
        {
            this.Notes = new ObservableCollection<Note>();
        }

        /// <summary>
        /// Добавить заметку в менеджер. 
        /// </summary>
        public void AddNote(Note note, bool setCurrent = true)
        {
            //Учесть то, что заметка может быть уже добавлена
            if (IfNoteContains(note) == false)
            {
                this.Notes.Add(note);
            }

            if (setCurrent)
            {
                SetCurrentNote(note);
            }
        }

        /// <summary>
        /// Удалить заметку в менеджер. 
        /// </summary>
        public void RemoveNote(Note note)
        {
            if (IfNoteContains(note) == false)
            {
                throw new Exception("Note is not in List before REMOVE operation!");
            }

            var noteIndex = Notes.IndexOf(note);
            int nextIndex = noteIndex == (Notes.Count - 1) ? noteIndex - 1 : noteIndex + 1;

            if (nextIndex == -1)
            {
                AddNote(new Note(), true);
                nextIndex = 1;
            }
            SetCurrentNote(Notes[nextIndex]);
            this.Notes.Remove(note);
            
        }

        /// <summary>
        /// Сравнивать заметки только по Id.
        /// </summary>
        /// <param name="note"></param>
        /// <returns></returns>
        public bool IfNoteContains(Note note)
        {
            return this.Notes?.Where(n => n.CreateTime == note.CreateTime)?.Count() > 0;
        }

        
        /// <summary>
        /// Поменять текущую заметку
        /// </summary>
        /// <param name="note"></param>
        public void SetCurrentNote(Note note)
        {
            if (note == null || this.Notes.Contains(note) == false) return;
            Note prev = this.CurrentNote;
            this.CurrentNote = note;
            CurrentNoteChanged?.Invoke(prev, note);
        }
    }
}
