namespace P07_01_DI_Contactos_TAPIADOR_rodrigo;

[ContentProperty(nameof(Key))]
public class LocalizationExtension : IMarkupExtension<BindingBase>
{
    public string Key { get; set; }

    public BindingBase ProvideValue(IServiceProvider serviceProvider) =>
        new Binding
        {
            Mode = BindingMode.OneWay,
            Path = $"[{Key}]",
            Source = LocalizationManager.Instance,
        };

    object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider) => ProvideValue(serviceProvider);
}