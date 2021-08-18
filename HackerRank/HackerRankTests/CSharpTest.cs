using System;
using System.Collections.Generic;
using System.Linq;

namespace HackeRank.HackerRankTests
{
    public static class CSharpTest
    {
        public static int Mirror(int n)
        {
            return n;
        }
    }

    public enum NoteStates
    { 
        completed = 0,
        valid,
        others
    }

    public class Note
    {
        public Note(string name, NoteStates state, int order)
        {
            Name = name;
            State = state;
            Order = order;
        }

        public string Name { get; set; }
        public NoteStates State { get; set; }
        public int Order { get; }
    }

    public class NotesStore
    {
        private List<Note> Notes { get; set; } = new List<Note>();
        public NotesStore() { }
        public void AddNote(String state, String name) 
        {
            ValidateState(state);
            ValidateName(name);

            NoteStates newNoteState = (NoteStates)Enum.Parse(typeof(NoteStates), state);
            int maxOrder = Notes.Where(note => note.State.Equals(newNoteState)).Select(note => note.Order).ToList().Max();

            Note newNote = new Note(name, newNoteState, maxOrder + 1);
            Notes.Add(newNote);
        }

        public List<String> GetNotes(String state) 
        {
            ValidateState(state);
            NoteStates stateAsEnum = (NoteStates)Enum.Parse(typeof(NoteStates), state);
            var notes = Notes.Where(note => note.State.Equals(stateAsEnum))
                        .OrderBy(note => note.Order)
                        .Select(note => note.Name).ToList();
            return notes;
        }

        private void ValidateState(string state)
        {
            bool validState = Enum.IsDefined(typeof(NoteStates), state);
            if (!validState)
            {
                throw new Exception($"Invalid state {state}");
            }
        }

        private void ValidateName(string name)
        { 
            if(String.IsNullOrEmpty(name))
            {
                throw new Exception("Name cannot be empty");
            }
        }
    }
}
