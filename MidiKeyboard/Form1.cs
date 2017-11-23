using NAudio.Midi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MidiKeyboard
{
    public partial class Form1 : Form
    {
        private int ZeroOcaveDo = 24;
        private MidiOut _midiOut;

        private int _selectedOctave;
        private int _selectedChannel;
        private int _selectedInstrument;

        private bool[] _keysPressed = new bool[12];

        public Form1()
        {
            InitializeComponent();

            for (int index = 0; index < 11; index++)
            {
                _keysPressed[index] = false;
            }

            comboBoxOctaves.DisplayMember = "Name";
            comboBoxOctaves.Items.AddRange(Octave.GetOctaves().ToArray());
            comboBoxOctaves.SelectedIndex = 2;
            _selectedChannel = ((Octave)comboBoxOctaves.Items[comboBoxOctaves.SelectedIndex]).Id * 12;

            for (int channel = 1; channel <= 16; channel++)
            {
                comboBoxChannel.Items.Add(channel);
            }
            comboBoxChannel.SelectedIndex = 0;
            _selectedChannel = (int)comboBoxChannel.Items[comboBoxChannel.SelectedIndex];

            comboBoxInstrument.DisplayMember = "TranslatedName";
            comboBoxInstrument.Items.AddRange(Instrument.GetAllInstruments().ToArray());
            comboBoxInstrument.SelectedIndex = 0;
            _selectedInstrument = ((Instrument)comboBoxInstrument.Items[comboBoxInstrument.SelectedIndex]).Id;

            for (int device = 0; device < MidiOut.NumberOfDevices; device++)
            {
                comboBoxMidiOutDevices.Items.Add(MidiOut.DeviceInfo(device).ProductName);
            }
            if (comboBoxMidiOutDevices.Items.Count > 0)
            {
                comboBoxMidiOutDevices.SelectedIndex = 0;
            }

            _midiOut = new MidiOut(comboBoxMidiOutDevices.SelectedIndex);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            _midiOut.Send(MidiMessage.ChangePatch(_selectedInstrument, _selectedChannel).RawData);
            if (e.KeyCode == Keys.Z && !_keysPressed[0])
            {
                _midiOut.Send(MidiMessage.StartNote(ZeroOcaveDo + _selectedOctave, 100, _selectedChannel).RawData);
                _keysPressed[0] = true;
            }
            if (e.KeyCode == Keys.S && !_keysPressed[1])
            {
                _midiOut.Send(MidiMessage.StartNote(ZeroOcaveDo + 1 + _selectedOctave, 100, _selectedChannel).RawData);
                _keysPressed[1] = true;
            }

            if (e.KeyCode == Keys.X && !_keysPressed[2])
            {
                _midiOut.Send(MidiMessage.StartNote(ZeroOcaveDo + 2 + _selectedOctave, 100, _selectedChannel).RawData);
                _keysPressed[2] = true;
            }
            if (e.KeyCode == Keys.D && !_keysPressed[3])
            {
                _midiOut.Send(MidiMessage.StartNote(ZeroOcaveDo + 3 + _selectedOctave, 100, _selectedChannel).RawData);
                _keysPressed[3] = true;
            }
            if (e.KeyCode == Keys.C && !_keysPressed[4])
            {
                _midiOut.Send(MidiMessage.StartNote(ZeroOcaveDo + 4 + _selectedOctave, 100, _selectedChannel).RawData);
                _keysPressed[4] = true;
            }
            if (e.KeyCode == Keys.V && !_keysPressed[5])
            {
                _midiOut.Send(MidiMessage.StartNote(ZeroOcaveDo + 5 + _selectedOctave, 100, _selectedChannel).RawData);
                _keysPressed[5] = true;
            }
            if (e.KeyCode == Keys.G && !_keysPressed[6])
            {
                _midiOut.Send(MidiMessage.StartNote(ZeroOcaveDo + 6 + _selectedOctave, 100, _selectedChannel).RawData);
                _keysPressed[6] = true;
            }
            if (e.KeyCode == Keys.B && !_keysPressed[7])
            {
                _midiOut.Send(MidiMessage.StartNote(ZeroOcaveDo + 7 + _selectedOctave, 100, _selectedChannel).RawData);
                _keysPressed[7] = true;
            }
            if (e.KeyCode == Keys.H && !_keysPressed[8])
            {
                _midiOut.Send(MidiMessage.StartNote(ZeroOcaveDo + 8 + _selectedOctave, 100, _selectedChannel).RawData);
                _keysPressed[8] = true;
            }
            if (e.KeyCode == Keys.N && !_keysPressed[9])
            {
                _midiOut.Send(MidiMessage.StartNote(ZeroOcaveDo + 9 + _selectedOctave, 100, _selectedChannel).RawData);
                _keysPressed[9] = true;
            }
            if (e.KeyCode == Keys.J && !_keysPressed[10])
            {
                _midiOut.Send(MidiMessage.StartNote(ZeroOcaveDo + 10 + _selectedOctave, 100, _selectedChannel).RawData);
                _keysPressed[10] = true;
            }
            if (e.KeyCode == Keys.M && !_keysPressed[11])
            {
                _midiOut.Send(MidiMessage.StartNote(ZeroOcaveDo + 11 + _selectedOctave, 100, _selectedChannel).RawData);
                _keysPressed[11] = true;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Z)
            {
                _midiOut.Send(MidiMessage.StopNote(ZeroOcaveDo + _selectedOctave, 100, _selectedChannel).RawData);
                _keysPressed[0] = false;
            }
            if (e.KeyCode == Keys.S)
            {
                _midiOut.Send(MidiMessage.StopNote(ZeroOcaveDo + 1 + _selectedOctave, 100, _selectedChannel).RawData);
                _keysPressed[1] = false;
            }
            if (e.KeyCode == Keys.X)
            {
                _midiOut.Send(MidiMessage.StopNote(ZeroOcaveDo + 2 + _selectedOctave, 100, _selectedChannel).RawData);
                _keysPressed[2] = false;
            }
            if (e.KeyCode == Keys.D)
            {
                _midiOut.Send(MidiMessage.StopNote(ZeroOcaveDo + 3 + _selectedOctave, 100, _selectedChannel).RawData);
                _keysPressed[3] = false;
            }
            if (e.KeyCode == Keys.C)
            {
                _midiOut.Send(MidiMessage.StopNote(ZeroOcaveDo + 4 + _selectedOctave, 100, _selectedChannel).RawData);
                _keysPressed[4] = false;
            }
            if (e.KeyCode == Keys.V)
            {
                _midiOut.Send(MidiMessage.StopNote(ZeroOcaveDo + 5 + _selectedOctave, 100, _selectedChannel).RawData);
                _keysPressed[5] = false;
            }
            if (e.KeyCode == Keys.G)
            {
                _midiOut.Send(MidiMessage.StopNote(ZeroOcaveDo + 6 + _selectedOctave, 100, _selectedChannel).RawData);
                _keysPressed[6] = false;
            }
            if (e.KeyCode == Keys.B)
            {
                _midiOut.Send(MidiMessage.StopNote(ZeroOcaveDo + 7 + _selectedOctave, 100, _selectedChannel).RawData);
                _keysPressed[7] = false;
            }
            if (e.KeyCode == Keys.H)
            {
                _midiOut.Send(MidiMessage.StopNote(ZeroOcaveDo + 8 + _selectedOctave, 100, _selectedChannel).RawData);
                _keysPressed[8] = false;
            }
            if (e.KeyCode == Keys.N)
            {
                _midiOut.Send(MidiMessage.StopNote(ZeroOcaveDo + 9 + _selectedOctave, 100, _selectedChannel).RawData);
                _keysPressed[9] = false;
            }
            if (e.KeyCode == Keys.J)
            {
                _midiOut.Send(MidiMessage.StopNote(ZeroOcaveDo + 10 + _selectedOctave, 100, _selectedChannel).RawData);
                _keysPressed[10] = false;
            }
            if (e.KeyCode == Keys.M)
            {
                _midiOut.Send(MidiMessage.StopNote(ZeroOcaveDo + 11 + _selectedOctave, 100, _selectedChannel).RawData);
                _keysPressed[11] = false;
            }
        }

        private void comboBoxOctaves_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedOctave = ((Octave)comboBoxOctaves.Items[comboBoxOctaves.SelectedIndex]).Id * 12;
        }

        private void comboBoxChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedChannel = (int)comboBoxChannel.Items[comboBoxChannel.SelectedIndex];
        }

        private void comboBoxInstrument_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedInstrument = ((Instrument)comboBoxInstrument.Items[comboBoxInstrument.SelectedIndex]).Id;
        }
    }
    
}
