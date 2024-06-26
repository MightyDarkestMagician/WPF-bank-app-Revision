﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbankHW12.Models.Operator
{
    /// <summary>
    /// Класс Consultant наследуется от абстрактного класса BankOperator и представляет собой
    /// роль консультанта в банковской системе. Консультанты обычно обладают ограниченными правами
    /// и выполняют задачи по обслуживанию клиентов, не занимаясь операциями, требующими расширенного доступа.
    /// 
    /// Наследование:
    /// Наследует свойства и методы из BankOperator, такие как Name и Color, которые в данном случае
    /// переопределяются для отражения специфических характеристик консультанта.
    /// 
    /// Конструктор:
    /// Конструктор класса Consultant инициализирует имя оператора как "Consultant" и устанавливает
    /// цвет ассоциированный с данной ролью как "Blue". Цвет "Blue" выбран для символизации
    /// доверия и надежности, что важно для лица, взаимодействующего с клиентами.
    /// 
    /// Основные характеристики и использование:
    /// - Имя и цвет помогают в идентификации роли оператора в системе и его представлении в интерфейсе пользователя.
    /// - Как часть системы управления ролями, консультант может быть задействован в операциях,
    ///   где необходим основной уровень взаимодействия без доступа к критически важным операциям или данным.
    /// 
    /// Пример использования:
    /// В реальных банковских приложениях консультанты часто занимаются предоставлением информации клиентам,
    /// помощью в решении стандартных задач и направлением запросов в соответствующие отделы.
    /// </summary>
    
    class Consultant : BankOperator     // Создаем оператора банка
    {
        public Consultant()
        {
            Name = "Consultant";       // Установка имени, указывающего на роль консультанта
            Color = "Blue";            // Выбор цвета для визуального отличия и ассоциации с доверием
            IsSuperUser = false;       // Режим СуперПользователя выключен 
        }
    }
}