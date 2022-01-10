# Курсовая работа по предмету "WEB-технологии"

Основная задача: Создание интернет-магазина. Классическое приложение создается при помощи MVC фреймворков\технологий (был выбран .Net Core MVC).

Подзачачи (этапы):

### 1) Верстка и простое манипулирование DOM элементами
Необходимо сверстать главную страницу, отображающую список товаров:
Должна быть возможность сортировать и фильтровать товары при помощи Ajax.

### 2) Cookies
Необходимо реализовать возможность выбора местоположения пользователя:
1. При первом посещении сайта пользователю показывается всплывающее окно со списком городов.
2. Пользователь выбирает город, информация записывается в cookies.
3. При следующих заходах на сайт у пользователя больше на запрашивается его местоположение.
4. На главной странице необходимо добавить ссылку\кнопку, при нажатии на которую можно сменить город вручную.

### 3) Session
На главной странице напротив каждого товара необходимо реализовать кнопку “Добавить в корзину”:
1. При нажатии на данную кнопку должен отправляться AJAX запрос к сервису, в сервисе данные корзины записываются в сессию.
2. После успешного добавления в корзину на главной странице должен обновиться счетчик товаров в корзине.

### 4) Работа с БД
Необходимо создать страницу “Корзина”:
1. При переходе на данную страницу должны отображаться товары, которые были добавлены пользователем в корзину (из сессии).
2. Должна быть возможность изменять количество товаров
3. Должна быть возможность удалять товары
4. Должна отображаться итоговая сумма заказа, которая должна автоматически пересчитываться
5. На странице должна быть кнопка “Оформить покупку”, при нажатии на которую происходила бы запись в БД с информацией о купленных товарах, времени покупки и городе пользователя