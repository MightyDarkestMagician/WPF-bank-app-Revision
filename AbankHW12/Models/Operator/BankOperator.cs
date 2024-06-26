﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AbankHW12.Models.Operator
{
    /// <summary>
    /// Абстрактный класс BankOperator описывает общую структуру и поведение операторов банка,
    /// которые могут иметь различные роли и уровни доступа в банковской системе.
    /// 
    /// Наследование:
    /// Конкретные роли, такие как консультант или менеджер, могут наследоваться от этого класса,
    /// переопределяя базовые значения и добавляя специфические функции.
    /// 
    /// Основные свойства:
    /// - Name: Имя оператора, которое может использоваться для идентификации в пользовательском интерфейсе или логах.
    /// - Color: Цвет, ассоциируемый с оператором, может использоваться для визуального отличия ролей операторов в интерфейсе.
    /// - IsSuperUser: Булево значение, указывающее, обладает ли оператор расширенными правами (например, доступ к конфиденциальной информации или управление другими пользователями).
    /// 
    /// Использование:
    /// Этот класс служит базой для создания различных типов операторов в банковской системе,
    /// позволяя легко расширять функциональность и добавлять новые типы операторов с уникальными свойствами и поведением.
    /// </summary>
    
    abstract class BankOperator                     // Добавление "операторов", можно добавить больше инструментария
    {
        private bool isSuperUser = false;           // По умолчанию выключено, указывает на отсутствие расширенных прав
        private string name = "Default";            // Имя оператора, "Default" как начальное значение
        private string color = "Black";             // Цвет, ассоциируемый с оператором, используется для UI

        public string Name      { get => name;        protected set => name = value; }              // Свойство для получения и установки имени оператора
        public string Color     { get => color;       protected set => color = value; }             // Свойство для получения и установки цвета
        public bool IsSuperUser { get => isSuperUser; protected set => isSuperUser = value; }       // Свойство для проверки наличия расширенных прав
    }
}