using System;
using System.Diagnostics;
using System.Threading;
using Commons.Music.Midi;
using NuGet.DependencyResolver;
using NUnit.Framework.Internal.Execution;
using osu.Framework.Allocation;
using osu.Framework.Audio.Sample;
using osu.Framework.Audio.Track;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Input.Events;
using osu.Framework.Screens;
using osu.Framework.Threading;
using osu.Framework.Timing;
using osuTK;
using osuTK.Graphics;
using osuTK.Input;
using TemplateGame.Game;

namespace MyNewGame.Game
{
    
    public partial class MainScreen : Screen
    {
        SpriteText text;
        SpinningBox b;
        SpinningBox wall;
        Stopwatch timePerJump;
        Stopwatch timePerParse;
        Sample sample;
        Track track;
        Balls p;
        private int frames;
        private float fps;
        private bool jumping = false;
        private bool left = false;
        private bool right = false;
        private bool up = false;
        private bool down = false;
        [BackgroundDependencyLoader]
        private void load(ISampleStore samples,ITrackStore tracks)
        {
            InternalChildren = new Drawable[]
            {
                new Box
                {
                    Colour = Color4.Violet,
                    RelativeSizeAxes = Axes.Both,
                },
                text = new SpriteText
                {
                    Y = 20,
                    Text = "Main Screen",
                    Anchor = Anchor.TopCentre,
                    Origin = Anchor.TopCentre,
                    Font = FontUsage.Default.With(size: 40)
                },
                wall = new SpinningBox
                {
                    Anchor = Anchor.TopLeft,
                    Origin = Anchor.TopLeft,
                },
                b = new SpinningBox
                {
                    Anchor = Anchor.Centre,
                },
                p = new Balls
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                }
                
                
            };
            timePerParse = Stopwatch.StartNew();
            timePerJump = Stopwatch.StartNew();
            sample = samples.Get("Boom.wav");
            sample.Volume.Value = 0.1f;
            /*track = tracks.Get("audio.wav");
            track.Volume.Value = 0.01f;
            track.StartAsync();
            */
        }
        protected override void Update()
        {
            if (timePerParse.ElapsedMilliseconds > 1)
            {
                Schedule(FixedUpdate);
            }
            /* 
                  frames ++;
                  if(timePerParse.ElapsedMilliseconds > 1000) {
                  fps = (float)(frames / timePerParse.ElapsedMilliseconds*1000);
                  text.Text = "Fps: " + fps.ToString(); ;
                  timePerParse.Restart();
                  frames = 0;
              }
              */

            

            base.Update();
            
            
        }

        private void FixedUpdate ()
        {
                if (up) { p.MoveTo(new Vector2(p.X, p.Y - 1)); }
                if (down) { p.MoveTo(new Vector2(p.X, p.Y + 1)); }
                if (left) { p.MoveTo(new Vector2(p.X - 1, p.Y)); }
                if (right) { p.MoveTo(new Vector2(p.X + 1, p.Y)); }
                if (jumping == true) { Jump(); }
                timePerParse.Restart();



        }
        protected override bool OnKeyDown(KeyDownEvent e)
        {

            if (e.Key == Key.Space && Jumping == false ) {
                Jumping = true;
            }
            if (e.Key == Key.W)
            {
                up = true;
            }

            if (e.Key == Key.A)
            {
                left = true;
            }

            if (e.Key == Key.S)
            {
                down = true;
            }

            if (e.Key == Key.D)
            {
                right = true;
            }


            return base.OnKeyDown(e);
        }
        protected override void OnKeyUp(KeyUpEvent e)
        {
            if (e.Key == Key.Space)
            {
                Jumping = false;
            }
            if (e.Key == Key.W)
            {
                up = false;
            }

            if (e.Key == Key.A)
            {
                left = false;
            }

            if (e.Key == Key.S)
            {
                down = false;
            }

            if (e.Key == Key.D)
            {
                right = false;
            }

        }
        public void Jump() {
            
            if (timePerJump.ElapsedMilliseconds > 500)
            {
                p.RotateTo(0).RotateTo(360, 200);
                sample.Play();
                timePerJump.Restart();
            }
            
        }
        public bool Jumping { get { return jumping; } set { jumping = value; } }
    }
}
