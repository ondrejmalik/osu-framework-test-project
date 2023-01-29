﻿using System;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osuTK;

namespace TemplateGame.Game
{
    public partial class Koule : CompositeDrawable
    {
        private Container box;
        private SpriteText text;
        private float speed = 2.0f;
        private float radius = 150.0f;
        public bool CanMove = false;
        public Vector2 Center = new Vector2(0 * 150, 0 * 150);
        public float Angle;
        public Sprite Sprite;
        public Koule()
        {
            AutoSizeAxes = Axes.Both;
            Origin = Anchor.Centre;
            Anchor = Anchor.Centre;
        }

        [BackgroundDependencyLoader]
        private void load(TextureStore textures)
        {
            InternalChild = box = new Container
            {
                AutoSizeAxes = Axes.Both,
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Children = new Drawable[]
                {
                    Sprite = new Sprite
                    {
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                    },
                    text = new SpriteText
                    {
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        Text = "",
                        Colour = Colour4.White,
                        Font = new FontUsage(size: 30),
                    }
                }
            };
        }

        protected override void LoadComplete()
        {
            base.LoadComplete();
        }
        protected override void Update()
        {
            if (CanMove)
            {
                base.Update();
                Angle += speed * ((float)Time.Elapsed) / 500;
                var x = Center.X + MathF.Cos(Angle) * radius;
                var y = Center.Y + MathF.Sin(Angle) * radius;
                Position = new Vector2(x, y);
                text.Text = Angle.ToString() + "     " + x.ToString() + "           " + y.ToString();
            }
        }
        public void Change(float druhyAngle)
        {
            Angle = druhyAngle + MathF.PI;
        }
    }
}
