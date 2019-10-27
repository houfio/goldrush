using GoldRush.Controllers;
using GoldRush.Controllers.Impl;
using GoldRush.Models;
using GoldRush.Views;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GoldRush
{
    public class Program
    {
        public Game Game { get; } = new Game();

        private bool _running = true;
        private Controller _controller;
        private View _view;
        private bool _queueClear = false;

        public Program()
        {
            Initialize();

            Task.Run(Update);
            Task.Run(Input).Wait();
        }

        public void OpenController<T>() where T : Controller<T>
        {
            var controller = (T)Activator.CreateInstance(typeof(T), new object[] { this });

            _controller = controller;
            _view = controller.CreateView();
            _queueClear = true;
        }

        public void Stop()
        {
            _running = false;
        }

        private void Initialize()
        {
            OpenController<StartController>();
        }

        private void Input()
        {
            while (_running)
            {
                var key = Console.ReadKey(true);

                foreach (var input in _view.Inputs)
                {
                    if (input.Character != key.KeyChar)
                    {
                        continue;
                    }

                    input.Action();
                }
            }
        }

        private void Update()
        {
            while (_running)
            {
                Game.Update();
                _controller.Update();

                var builder = new StringBuilder();

                _view.Draw(builder);

                if (_queueClear)
                {
                    Console.Clear();

                    _queueClear = false;
                }

                Console.CursorVisible = false;
                Console.SetCursorPosition(0, 0);
                Console.Write(builder.ToString());

                Thread.Sleep(100);
            }
        }

        public static void Main(string[] args)
        {
            Console.Title = "GoldRush";

            new Program();
        }
    }
}
