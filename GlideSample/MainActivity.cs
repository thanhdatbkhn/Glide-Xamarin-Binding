using Android.App;
using Android.Widget;
using Android.OS;
using Com.Bumptech.Glide;
using Com.Bumptech.Glide.Request;
using Com.Bumptech.Glide.Load.Resource.Drawable;

namespace GlideSample
{
	[Activity(Label = "GlideSample", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		Button button;
		ImageView img1, img2, img3, img4;
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			button = FindViewById<Button>(Resource.Id.button1);

			img1 = FindViewById<ImageView>(Resource.Id.imageView1);
			img2 = FindViewById<ImageView>(Resource.Id.imageView2);
			img3 = FindViewById<ImageView>(Resource.Id.imageView3);
			img4 = FindViewById<ImageView>(Resource.Id.imageView4);

			button.Click += (obj, e) =>
			{
				ShowImage();
			};
		}

		void ShowImage()
		{
			base.OnResume();

            //basic
            var basicOption = new RequestOptions();
            basicOption.DontAnimate();
            Glide.With(this).Load("http://ketquaviet.vn/app/img/logo-kqv.png").Apply(basicOption).Into(img1);

			//transform
            var transformOption = new RequestOptions();
            transformOption.Transform(new CircleTransform(this));
			Glide.With(this).Load("http://ketquaviet.vn/app/img/logo-kqv.png")
                 .Apply(transformOption)
				 //.Transform(new CircleTransform(this))
                 .Into(img2);

			//animation
            var animOption = new DrawableTransitionOptions();
			var anim = new Android.Views
								  .Animations.ScaleAnimation(0, 1, 0, 1,
												  Android.Views.Animations.Dimension.RelativeToSelf, 0.5f,
												 Android.Views.Animations.Dimension.RelativeToSelf, 0.5f);
			anim.Duration = 2000;
			anim.RepeatCount = 0;
            //animOption.tra
			Glide.With(this).Load("http://ketquaviet.vn/app/img/logo-kqv.png")
                 //.Transition(animOption.c)
				 //.Animate(anim)
                 .Into(img3);

			//support gif
			Glide.With(this).Load("http://ketquaviet.vn/uploads/web--landingkqv1.0.1.gif").FitCenter().Into(img4);
		}
	}
}


