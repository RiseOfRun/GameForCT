namespace EasyProgram
{
    class Cat
    {
        public int speed = 5;
        public int position = 0;

        public int Walk()
        {
            position += speed;
            return position;
        }
    }
}