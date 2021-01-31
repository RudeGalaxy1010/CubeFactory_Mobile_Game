using System.Collections;
using System.Collections.Generic;

public interface IGameDataStorage
{
    IEnumerator Init(UI UI);
    void SaveAll();
    List<Product> GetAllProducts();
}
