1. Количество часов потраченных на разработку: 22

2. Для работы игры на сервере нужны:

    Системы: 
    - HoldButtonsSystem 
    - MoveSystem
    - OpenDoorsSystem 
    - MoveToMouseClickSystem
    
    Компоненты:
    - ButtonComponent
    - DoorComponent
    - LocalPositionComponent
    - MouseClickEventComponent
    - MovableComponent
    - InputEventComponent
    - RadiusComponent


- Для эмуляции кликов по экрану система на стороне сервера должна создавать компонент MouseClickEventComponent с позицией
    куда персонаж будет двигаться.
    
- Также, для того чтобы сервер знал какие объекты где находятся, необходимо синхронизировать уровень, отправив его 
    с сервера на клиент, либо используя конфиги, так как в задании указано "В сцене заранее расставлено произвольное количество 
    пар дверей и КРУГЛЫХ кнопок" уровень загружается из префаба с сохраненными позициями
