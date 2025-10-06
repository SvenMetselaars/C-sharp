using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ws72_APPR
{
    class Piece
    {
        private string name = "";
        private string moveOptions = "";
        private int curHor, curVer, newHor, newVer;

        public Piece(string c_name)
        {
            name = c_name;
        }

        public void SetLocation(int _newHor, int _newVer)
        {
            curHor = _newHor;
            curVer = _newVer;
        }

        public string GetMoveoptions(int _newHor, int _newVer, List<string> piecesList)
        {
            newHor = _newHor;
            newVer = _newVer;
            moveOptions = "";

            switch (name)
            {
                case "Rook": MoveRook(piecesList); break;
                case "Knight": MoveKnight(); break;
                case "Queen": MoveQueen(piecesList); break;
                case "Bishop": MoveBishop(piecesList); break;
                case "King": MoveKing(); break;
                case "Pawn": MovePawn(); break;
                default:
                    break;
            }
            return moveOptions;
        }

        public void MoveRook(List<string> piecesList)
        {
            int temp_hor = Math.Abs(newHor - curHor);
            int temp_ver = Math.Abs(newVer - curVer);
            bool isPathClear = true;

            int stepHor = (newHor > curHor) ? 1 : (newHor < curHor ? -1 : 0);
            int stepVer = (newVer > curVer) ? 1 : (newVer < curVer ? -1 : 0);

            // Rook only moves horizontally or vertically, so check the valid direction
            if (newHor == curHor || newVer == curVer)
            {
                int maxSteps = Math.Max(temp_hor, temp_ver);

                // Move in horizontal direction if horizontal step is non-zero
                if (stepHor != 0)
                {
                    for (int i = 1; i < temp_hor; i++)
                    {
                        int checkHor = curHor + i * stepHor;
                        int checkVer = curVer;
                        string checkPosition = $"{checkHor},{checkVer}";

                        foreach (string piece in piecesList)
                        {
                            string[] parts = piece.Split('-');
                            string piecePosition = parts[1];

                            if (piecePosition == checkPosition)
                            {
                                isPathClear = false;
                                break;
                            }
                        }

                        if (!isPathClear) break;
                    }
                }

                // Move in vertical direction if vertical step is non-zero
                if (stepVer != 0)
                {
                    for (int i = 1; i < temp_ver; i++)
                    {
                        int checkHor = curHor;
                        int checkVer = curVer + i * stepVer;
                        string checkPosition = $"{checkHor},{checkVer}";

                        foreach (string piece in piecesList)
                        {
                            string[] parts = piece.Split('-');
                            string piecePosition = parts[1];

                            if (piecePosition == checkPosition)
                            {
                                isPathClear = false;
                                break;
                            }
                        }

                        if (!isPathClear) break;
                    }
                }

                if (isPathClear)
                {
                    moveOptions = $"{newHor}{newVer}";
                }
            }
        }
        public void MoveKnight()
        {
            int temp_hor = Math.Abs(newHor - curHor);
            int temp_ver = Math.Abs(newVer - curVer);

            if (temp_ver == 2 && temp_hor == 1)
            {
                moveOptions = $"{newHor}{newVer}";  
            }
            else if (temp_hor == 2 && temp_ver == 1)
            {
                moveOptions = $"{newHor}{newVer}";
            }
        }
        public void MoveQueen(List<string> piecesList)
        {
            int temp_hor = Math.Abs(newHor - curHor);
            int temp_ver = Math.Abs(newVer - curVer);
            bool isPathClear = true;

            int stepHor = (newHor > curHor) ? 1 : (newHor < curHor ? -1 : 0);
            int stepVer = (newVer > curVer) ? 1 : (newVer < curVer ? -1 : 0);

            if (newHor == curHor || newVer == curVer || temp_hor == temp_ver)
            {
                for (int i = 1; i < Math.Max(temp_hor, temp_ver); i++)
                {
                    int checkHor = curHor + i * stepHor;
                    int checkVer = curVer + i * stepVer;
                    string checkPosition = $"{checkHor},{checkVer}";

                    foreach (string piece in piecesList)
                    {
                        string[] parts = piece.Split('-');
                        string piecePosition = parts[1];

                        if (piecePosition == checkPosition)
                        {
                            isPathClear = false;
                            break;
                        }
                    }

                    if (!isPathClear) break;
                }

                if (isPathClear)
                {
                    moveOptions = $"{newHor}{newVer}";
                }
            }
        }
        public void MoveBishop(List<string> piecesList)
        {
            bool isPathClear = true;

            // Ensure the move is diagonal (i.e., both horizontal and vertical changes are equal)
            if (Math.Abs(newHor - curHor) == Math.Abs(newVer - curVer))
            {
                int stepHor = (newHor > curHor) ? 1 : (newHor < curHor ? -1 : 0);
                int stepVer = (newVer > curVer) ? 1 : (newVer < curVer ? -1 : 0);
                int maxSteps = Math.Abs(newHor - curHor); // The number of steps to check along the diagonal path

                // Check each position along the diagonal path
                for (int i = 1; i < maxSteps; i++)
                {
                    int checkHor = curHor + i * stepHor;
                    int checkVer = curVer + i * stepVer;
                    string checkPosition = $"{checkHor},{checkVer}";

                    foreach (string piece in piecesList)
                    {
                        string[] parts = piece.Split('-');
                        string piecePosition = parts[1];

                        if (piecePosition == checkPosition)
                        {
                            isPathClear = false;
                            return; // No need to check further if path is blocked
                        }
                    }
                }

                // If the path is clear, set the move option
                if (isPathClear)
                {
                    moveOptions = $"{newHor}{newVer}";
                }
            }
            else
            {
                isPathClear = false; // Not a valid diagonal move if horizontal and vertical differences aren't the same
            }
        }
        public void MoveKing()
        {
            int temp_hor = Math.Abs(newHor - curHor);
            int temp_ver = Math.Abs(newVer - curVer);

            // The King moves one square in any direction
            if (temp_hor <= 1 && temp_ver <= 1)
            {
                moveOptions = $"{newHor}{newVer}";
            }
        }
        public void MovePawn()
        {
            int temp_hor = Math.Abs(newHor - curHor);
            int temp_ver = Math.Abs(newVer - curVer);

            // Pawn can only move one step diagonally (like a mini-bishop)
            if (temp_hor == 1 && temp_ver == 1)
            {
                moveOptions = $"{newHor}{newVer}";
            }
        }

        //int temp_hor = Math.Abs(newHor - curHor);
        //int temp_ver = Math.Abs(newVer - curVer);

        //    // Check for Rook-like movement (horizontal or vertical)
        //    if (newHor == curHor || newVer == curVer)
        //    {
        //        moveOptions = $"{newHor}{newVer}";
        //    }
        //    // Check for Bishop-like movement (diagonal)
        //    else if (temp_hor == temp_ver)
        //    {
        //        moveOptions = $"{newHor}{newVer}";
        //    }

        //        if (newHor == curHor || newVer == curVer)
        //{
        //    moveOptions = $"{newHor}{newVer}";
        //}
        //int temp_hor = Math.Abs(newHor - curHor);
        //int temp_ver = Math.Abs(newVer - curVer);
        //    if (temp_hor == temp_ver)
        //    {
        //        moveOptions = $"{newHor}{newVer}";
        //    }
}
}
