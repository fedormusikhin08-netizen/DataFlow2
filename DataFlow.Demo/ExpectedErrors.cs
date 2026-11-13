// Три ошибки компиляции из шага 11.
// Блоки закомментированы, чтобы проект собирался: иначе dotnet build падает.
// Чтобы повторить ошибку, раскомментируйте нужный блок и соберите проект.

/*
// 1. CS0029: Container<Dog> нельзя неявно привести к Container<Animal>.
using DataFlow.Core;
using DataFlow.Demo;

var dogBox = new Container<Dog>(new Dog { Name = "Рекс" });
Container<Animal> animalBox = dogBox;
*/

/*
// 2. CS1961: out T нельзя использовать на входе.
using DataFlow.Core;

public interface IProbeContainer<out T>
{
    T GetItem();
    void Put(T item);
}
*/

/*
// 3. CS0311: string не реализует IEntity.
using DataFlow.Core;

var badRepo = new InMemoryRepository<string>();
*/
