using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZorkBork.Wrappers;
using System.Drawing;
using Console = Colorful.Console;
using Colorful;

namespace ZorkBork
{
    public class Doel : Interactable
    {
        public override void Interact(Speler speler)
        {
              Console.WriteAscii("MISSIE GESLAAGD!", Color.FromArgb(200, 200, 200));

            Console.WriteLine("------------------MISSIE GESLAAGD!------------------");
            Console.WriteLine("Score: " + speler.Score);
            Console.WriteLine("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");

            Console.WriteWithGradient(@"


         .* *.               `o`o`
         *. .*              o`o`o`o      ^,^,^
           * \               `o`o`     ^,^,^,^,^
              \     ***        |       ^,^,^,^,^
               \   *****       |        /^,^,^
                \   ***        |       /
    ~@~*~@~      \   \         |      /
  ~*~@~*~@~*~     \   \        |     /
  ~*~@smd@~*~      \   \       |    /     #$#$#        .`'.;.
  ~*~@~*~@~*~       \   \      |   /     #$#$#$#   00  .`,.',
    ~@~*~@~ \        \   \     |  /      /#$#$#   /|||  `.,'
_____________\________\___\____|_/______/_________|\/\___||______


", Color.Blue, Color.Red, 10);
            Console.ResetColor();
        }
    }
}
