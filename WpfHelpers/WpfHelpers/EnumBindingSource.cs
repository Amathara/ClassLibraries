using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Markup;

namespace WpfHelpers
{
    public class EnumBindingSource : MarkupExtension
    {
        public Type EnumType { get; private set; }
        public EnumBindingSource() { }
        public EnumBindingSource(Type enumType)
        {
            if (enumType == null || !enumType.IsEnum)
                throw new Exception("EnumType must not be null and of type Enum");
            EnumType = enumType;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Enum.GetValues(EnumType);
        }
    }

    //      Cane be used in the xaml like so: - The enum name used here is "Condition" - ofc it can be used in different ways.
    //      <Label Content="Stand" Background="AliceBlue"/>
    //      <ComboBox Margin = "5,0,5,15"
    //      ItemsSource="{Binding Source={local:EnumBindingSource {x:Type model:Condition}}}"
    //      SelectedItem="{Binding SelectedItem.Condition, UpdateSourceTrigger=PropertyChanged}"
    //      Background="Honeydew"/>

}