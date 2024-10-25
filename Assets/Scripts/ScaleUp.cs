using UnityEngine;

public class ScaleUp : MonoBehaviour
{
    public float scaleSpeed = 1f; // Скорость увеличения
    public Vector3 targetScale = new Vector3(1f, 1f, 1f); // Целевой размер

    private float currentY = 0.1f; // Текущее значение Y
    private bool scalingY = false; // Флаг, указывающий, нужно ли увеличивать Y

    private void Start()
    {
        // Убедитесь, что куб начинается с небольшого размера
        transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        currentY = 0.1f; // Начальное значение Y
    }

    private void Update()
    {
        // Увеличиваем по X и Z
        Vector3 newScale = Vector3.Lerp(transform.localScale, new Vector3(targetScale.x, currentY, targetScale.z), scaleSpeed * Time.deltaTime);
        transform.localScale = newScale;

        // Проверяем, достигли ли мы целевого размера по X и Z
        if (Vector3.Distance(new Vector3(transform.localScale.x, 0, transform.localScale.z), new Vector3(targetScale.x, 0, targetScale.z)) < 0.01f)
        {
            scalingY = true; // Переходим к увеличению Y
        }

        // Увеличиваем Y
        if (scalingY)
        {
            // Увеличиваем текущее значение Y
            currentY = Mathf.Lerp(currentY, targetScale.y, scaleSpeed * Time.deltaTime);

            // Обновляем масштаб куба по Y
            transform.localScale = new Vector3(transform.localScale.x, currentY, transform.localScale.z);

            // Сместим куб так, чтобы он "вырастал" вперед
            float heightDifference = (currentY - transform.localScale.y) / 2; // Половина увеличения
            transform.position += new Vector3(0, heightDifference, 0); // Смещение вверх
        }

        // Остановка увеличения, если достигнут целевой размер
        if (Vector3.Distance(transform.localScale, targetScale) < 0.01f)
        {
            enabled = false; // Отключаем скрипт после достижения целевого размера
        }
    }
}
