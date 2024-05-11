using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CharberryTree tree = new CharberryTree();
            Notifier notifier = new Notifier(tree);
            Harvester harvester = new Harvester(tree);
            

            while (true)
            {
                tree.MaybeGrow();
            }



        }
    }
    
    
    
    public class CharberryTree
    {
        private Random _random = new Random();
        public event Action Ripened;
        
        public bool Ripe { get; set; }

        public void MaybeGrow()
        {
            if (_random.NextDouble() < 0.0000001 && !Ripe)
            {
                Ripe = true;
                Ripened?.Invoke();
            }
        }
        
    }



    public class Notifier
    {
        
        public Notifier(CharberryTree tree)
        {
            tree.Ripened += OnTreeBloom;
        }

        public void OnTreeBloom()
        {
            Console.WriteLine("tree has bloomed!!!");
        }
        
    }

    public class Harvester
    {
        private CharberryTree _tree;
        public Harvester(CharberryTree tree)
        {
            tree.Ripened += OnTreeBloom;
            _tree = tree;
        }

        public void OnTreeBloom()
        {
            _tree.Ripe = false;
        }
    }
    
    
    
    
    
    
    
    
    
}