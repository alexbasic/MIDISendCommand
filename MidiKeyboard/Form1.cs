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

            for (int octave = -2; octave <= 8; octave++)
            {
                comboBoxOctaves.Items.Add(octave);
            }
            comboBoxOctaves.SelectedIndex = 2;
            _selectedChannel = (int)comboBoxOctaves.Items[comboBoxOctaves.SelectedIndex] * 12;

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
            _midiOut.Send(MidiMessage.ChangePatch(_selectedInstrument, 1).RawData);
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
            _selectedOctave = (int)comboBoxOctaves.Items[comboBoxOctaves.SelectedIndex] * 12;
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

    public class Instrument 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TranslatedName { get; set; }

        public static List<Instrument> GetAllInstruments()
        {
            return new List<Instrument> 
            {
                new Instrument { Id = 0, Name = "Acoustic Piano", TranslatedName = "Фортепиано"},
new Instrument { Id = 1, Name = "Bright Piano", TranslatedName = "Концертный рояль"},
new Instrument { Id = 2, Name = "Electric Grand Piano", TranslatedName = "Электрический рояль"},
new Instrument { Id = 3, Name = "Honky Tonk Piano", TranslatedName = "Расстроенное фортепиано"},
new Instrument { Id = 4, Name = "Electric Piano I", TranslatedName = "Электропиано 1"},
new Instrument { Id = 5, Name = "Electric Piano II", TranslatedName = "Электропиано 2"},
new Instrument { Id = 6, Name = "Harpsichord", TranslatedName = "Клавесин"},
new Instrument { Id = 7, Name = "Clavinet", TranslatedName = "Клавинет"},
new Instrument { Id = 8, Name = "Celesta", TranslatedName = "Челеста"},
new Instrument { Id = 9, Name = "Glockenspiel", TranslatedName = "Колокольчики"},
new Instrument { Id = 10, Name = "Music Box", TranslatedName = "Музыкальная шкатулка"},
new Instrument { Id = 11, Name = "Vibraphone", TranslatedName = "Вибрафон"},
new Instrument { Id = 12, Name = "Marimba", TranslatedName = "Маримба"},
new Instrument { Id = 13, Name = "Xylophone", TranslatedName = "Ксилофон"},
new Instrument { Id = 14, Name = "Tubular Bells", TranslatedName = "Колокола (трубчатые)"},
new Instrument { Id = 15, Name = "Dulcimer", TranslatedName = "Цимбалы"},
new Instrument { Id = 16, Name = "Drawbar Organ", TranslatedName = "Орган"},
new Instrument { Id = 17, Name = "Percussive Organ", TranslatedName = "Орган с ударной атакой"},
new Instrument { Id = 18, Name = "Rock Organ", TranslatedName = "Рок-орган"},
new Instrument { Id = 19, Name = "Church Organ", TranslatedName = "Церковный орган"},
new Instrument { Id = 20, Name = "Reed Organ", TranslatedName = "Язычковый орган"},
new Instrument { Id = 21, Name = "Accordion", TranslatedName = "Аккордеон"},
new Instrument { Id = 22, Name = "Harmonica", TranslatedName = "Губная гармошка"},
new Instrument { Id = 23, Name = "Tango Accordion", TranslatedName = "Танго-аккордеон"},
new Instrument { Id = 24, Name = "Nylon Guitar", TranslatedName = "Гитара (нейлоновые струны)"},
new Instrument { Id = 25, Name = "Steel String", TranslatedName = "Гитара (стальные струны)"},
new Instrument { Id = 26, Name = "Jazz Guitar", TranslatedName = "Джазовая гитара"},
new Instrument { Id = 27, Name = "Clean Guitar", TranslatedName = "Акустическая соло-гитара"},
new Instrument { Id = 28, Name = "Muted Guitar", TranslatedName = "Приглушенная гитара"},
new Instrument { Id = 29, Name = "Overdriven Guitar", TranslatedName = "Гитара с перемодуляцией"},
new Instrument { Id = 30, Name = "Distortion Guitar", TranslatedName = "Гитара с искажениями (эффект дисторшн)"},
new Instrument { Id = 31, Name = "Guitar Harmonics", TranslatedName = "Гитарные гармоник"},
new Instrument { Id = 32, Name = "Acoustic Bass", TranslatedName = "Бас-гитара"},
new Instrument { Id = 33, Name = "Fingered Bass (Electric Bass)", TranslatedName = "Бас-гитара (пальцевым щипком)"},
new Instrument { Id = 34, Name = "Picked Bass", TranslatedName = "Бас-гитара (медиатором)"},
new Instrument { Id = 35, Name = "Fretless Bass", TranslatedName = "Безладовая бас-гитара"},
new Instrument { Id = 36, Name = "Slap Bass I", TranslatedName = "Слэп 1"},
new Instrument { Id = 37, Name = "Slap Bass II", TranslatedName = "Слэп 2"},
new Instrument { Id = 38, Name = "Synth Bass I", TranslatedName = "Синтезаторный бас 1"},
new Instrument { Id = 39, Name = "Synth Bass II", TranslatedName = "Синтезаторный бас 2"},
new Instrument { Id = 40, Name = "Violin", TranslatedName = "Скрипка"},
new Instrument { Id = 41, Name = "Viola", TranslatedName = "Альт"},
new Instrument { Id = 42, Name = "Cello", TranslatedName = "Виолончель"},
new Instrument { Id = 43, Name = "Contrabass", TranslatedName = "Контрабас"},
new Instrument { Id = 44, Name = "Tremolo Strings", TranslatedName = "Тремолирующие струнные"},
new Instrument { Id = 45, Name = "Pizzicato Strings", TranslatedName = "Струнные пиццикато"},
new Instrument { Id = 46, Name = "Harp", TranslatedName = "Арфа"},
new Instrument { Id = 47, Name = "Timpani", TranslatedName = "Литавры"},
new Instrument { Id = 48, Name = "String Ensemble I", TranslatedName = "Струнные 1"},
new Instrument { Id = 49, Name = "String Ensemble II", TranslatedName = "Струнные 2"},
new Instrument { Id = 50, Name = "Synth Strings I", TranslatedName = "Синтезированные струнные 1"},
new Instrument { Id = 51, Name = "Synth Strings II", TranslatedName = "Синтезированные струнные 2"},
new Instrument { Id = 52, Name = "Choir Aahs", TranslatedName = "Хоровое а"},
new Instrument { Id = 53, Name = "Voice Oohs", TranslatedName = "Голосовое о"},
new Instrument { Id = 54, Name = "Synth Voice", TranslatedName = "Синтезированный голос"},
new Instrument { Id = 55, Name = "Orchestra Hit", TranslatedName = "Оркестровый акцент"},
new Instrument { Id = 56, Name = "Trumpet", TranslatedName = "Труба"},
new Instrument { Id = 57, Name = "Trombone", TranslatedName = "Тромбон"},
new Instrument { Id = 58, Name = "Tuba", TranslatedName = "Туба"},
new Instrument { Id = 59, Name = "Muted Trumpet", TranslatedName = "Засурдиненная труба"},
new Instrument { Id = 60, Name = "French Horn", TranslatedName = "Валторна"},
new Instrument { Id = 61, Name = "Brass Section", TranslatedName = "Медная духовая группа"},
new Instrument { Id = 62, Name = "Synth Brass I", TranslatedName = "Синтезированные медные 1"},
new Instrument { Id = 63, Name = "Synth Brass II", TranslatedName = "Синтезированные медные 2"},
new Instrument { Id = 64, Name = "Soprano Saxophone", TranslatedName = "Сопрановый саксофон"},
new Instrument { Id = 65, Name = "Alto Saxophone", TranslatedName = "Альтовый саксофон"},
new Instrument { Id = 66, Name = "Tenor Saxophone", TranslatedName = "Теноровый саксофон"},
new Instrument { Id = 67, Name = "Baritone Saxophone", TranslatedName = "Баритоновый саксофон"},
new Instrument { Id = 68, Name = "Oboe", TranslatedName = "Гобой"},
new Instrument { Id = 69, Name = "English Horn", TranslatedName = "Английский рожок"},
new Instrument { Id = 70, Name = "Bassoon", TranslatedName = "Фагот"},
new Instrument { Id = 71, Name = "Clarinet", TranslatedName = "Кларнет"},
new Instrument { Id = 72, Name = "Piccolo", TranslatedName = "Флейта пикколо"},
new Instrument { Id = 73, Name = "Flute", TranslatedName = "Флейта"},
new Instrument { Id = 74, Name = "Recorder", TranslatedName = "Блокфлейта"},
new Instrument { Id = 75, Name = "Pan Flute", TranslatedName = "Флейта Пана"},
new Instrument { Id = 76, Name = "Blown Bottle", TranslatedName = "Дуновение в бутылку"},
new Instrument { Id = 77, Name = "Shakuhachi", TranslatedName = "Шакухачи"},
new Instrument { Id = 78, Name = "Whistle", TranslatedName = "Свист"},
new Instrument { Id = 79, Name = "Ocarina", TranslatedName = "Окарина"},
new Instrument { Id = 80, Name = "Square Lead", TranslatedName = "Соло-гитара (прямоугольнаяволна)"},
new Instrument { Id = 81, Name = "Sawtooth Lead", TranslatedName = "Соло-гитара (пилообразная волна)"},
new Instrument { Id = 82, Name = "Calliope Lead", TranslatedName = "Calliope-гитара"},
new Instrument { Id = 83, Name = "Chiff Lead", TranslatedName = "Chiff-гитара"},
new Instrument { Id = 84, Name = "Charang Lead", TranslatedName = "Charang-гитара"},
new Instrument { Id = 85, Name = "Voice Lead", TranslatedName = "Соло-гитара (голосовой тембр)"},
new Instrument { Id = 86, Name = "Fifth Lead", TranslatedName = "Соло-гитара (с квинтовым обертоном)"},
new Instrument { Id = 87, Name = "Bass&Lead", TranslatedName = "Бас и соло-гитара"},
new Instrument { Id = 88, Name = "New Age Pad", TranslatedName = "Синтезаторный звук нью-эйдж"},
new Instrument { Id = 89, Name = "Warm Pad", TranslatedName = "Теплый синтезаторный звук"},
new Instrument { Id = 90, Name = "Polysynth Pad", TranslatedName = "Полисинтезатор"},
new Instrument { Id = 91, Name = "Choir Pad", TranslatedName = "Хоровой синтезаторный звук"},
new Instrument { Id = 92, Name = "Bowed Pad", TranslatedName = "Смычковый синтезаторный звук"},
new Instrument { Id = 93, Name = "Metallic Pad", TranslatedName = "Металлический синтезаторный звук"},
new Instrument { Id = 94, Name = "Halo Pad", TranslatedName = "Ореол"},
new Instrument { Id = 95, Name = "Sweep Pad", TranslatedName = "Качающийся звук"},
new Instrument { Id = 96, Name = "Rain", TranslatedName = "Дождь"},
new Instrument { Id = 97, Name = "Soundtrack", TranslatedName = "Звуковая дорожка"},
new Instrument { Id = 98, Name = "Crystal", TranslatedName = "Хрусталь"},
new Instrument { Id = 99, Name = "Atmosphere", TranslatedName = "Атмосфера"},
new Instrument { Id = 100, Name = "Brightness", TranslatedName = "Яркость"},
new Instrument { Id = 101, Name = "Goblins", TranslatedName = "Гоблины"},
new Instrument { Id = 102, Name = "Echo Sweep", TranslatedName = "Качающееся эхо"},
new Instrument { Id = 103, Name = "Sci Fi", TranslatedName = "SciFi"},
new Instrument { Id = 104, Name = "Sitar", TranslatedName = "Ситар"},
new Instrument { Id = 105, Name = "Banjo", TranslatedName = "Банджо"},
new Instrument { Id = 106, Name = "Shamisen", TranslatedName = "Шамисен"},
new Instrument { Id = 107, Name = "Koto", TranslatedName = "Кото"},
new Instrument { Id = 108, Name = "Kalimba", TranslatedName = "Калимба"},
new Instrument { Id = 109, Name = "Bagpipe", TranslatedName = "Волынка"},
new Instrument { Id = 110, Name = "Fiddle", TranslatedName = "Уличная скрипка"},
new Instrument { Id = 111, Name = "Shanai", TranslatedName = "Санаи"},
new Instrument { Id = 112, Name = "Tinkle Bell", TranslatedName = "Звенящий колокольчик"},
new Instrument { Id = 113, Name = "Agogo", TranslatedName = "Агого"},
new Instrument { Id = 114, Name = "Steel Drums", TranslatedName = "Стальные барабаны"},
new Instrument { Id = 115, Name = "Woodblock", TranslatedName = "Коробочка (гольцтон)"},
new Instrument { Id = 116, Name = "Taiko Drum", TranslatedName = "Таико"},
new Instrument { Id = 117, Name = "Melodic Tom", TranslatedName = "Мелодический томтом"},
new Instrument { Id = 118, Name = "Synth Drum", TranslatedName = "Синтезированный барабан"},
new Instrument { Id = 119, Name = "Reverse Cymbal", TranslatedName = "Реверсивная тарелка (запись в обратную сторону)"},
new Instrument { Id = 120, Name = "Guitar Fret Noise", TranslatedName = "Шум гитарных ладов"},
new Instrument { Id = 121, Name = "Breath Noise", TranslatedName = "Дыхание"},
new Instrument { Id = 122, Name = "Seashore", TranslatedName = "Морской берег"},
new Instrument { Id = 123, Name = "Bird Tweet", TranslatedName = "Чириканье"},
new Instrument { Id = 124, Name = "Telephone Ring", TranslatedName = "Телефонный звонок"},
new Instrument { Id = 125, Name = "Helicopter", TranslatedName = "Вертолет"},
new Instrument { Id = 126, Name = "Applause", TranslatedName = "Аплодисменты"},
new Instrument { Id = 127, Name = "Gunshot", TranslatedName = "Выстрел"}
            };
        }
    }
}
