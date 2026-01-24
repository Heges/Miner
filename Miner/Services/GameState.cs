using MinerDomain.Interfaces;

namespace Miner.Services
{
    public class GameState : IGameState
    {
        //игровая информация
        public int CurrentLevelId { get; set; }
        //таймер отображающий время
        public double Timer {  get; set; }
        //количество выполненых шагов
        public int Steps { get; set; }
        //счетчик флагов
        public int Flags { get; set; }
        //ширина поля
        public int Width { get; set; }
        //высота поля
        public int Height { get; set; }
        //количество бомб на карту
        public int BombCount {  get; set; }
        //начальная позиция курсора
        public int InitialCursorPositionX { get; set; }
        public int InitialCursorPositionY { get; set; }
        //нынешняя позиция курсора
        public int CurrentCursorPositionX { get; set; }
        public int CurrentCursorPositionY { get; set; }
        //игра окончена?
        public bool IsGameOver { get; set; }
        //игра выйграна?
        public bool IsGameWin { get; set; }
    }
}
