using System.Data.SqlClient;
using System.Linq;

namespace Intive.BikeRental.Utility
{
    public class SqlCreateParameterBuilder<TCreateParameter> where TCreateParameter : struct
    {
        private readonly ParameterDefinitionsModel _model = new ParameterDefinitionsModel();

        public interface ICreatingBuilder<TCreateBuilderParameter> where TCreateBuilderParameter : struct
        {
            SqlCreateParameterBuilder<TCreateParameter> On(object parameterValue);

            SqlCreateParameterBuilder<TCreateParameter> On();
        }

        public ICreatingBuilder<TCreateParameter> Bind<TEnum>(TEnum enumValue) where TEnum : struct
        {
            var member = enumValue.GetType().GetField(enumValue.ToString());
            var createAtt = (CreateFieldAttribute)member.GetCustomAttributes(typeof(CreateFieldAttribute), false).First();
            return new ParameterBuilder(this, createAtt.Process(enumValue));
        }
    
        public SqlParameter[] Build()
        {
            var parameters = _model.ParameterDefinition.ToArray();
            _model.ParameterDefinition.Clear();
            return parameters;
        }

        public abstract class SubBuilderBase
        {
            protected SubBuilderBase(SqlCreateParameterBuilder<TCreateParameter> builder)
            {
                Builder = builder;
            }

            protected SqlCreateParameterBuilder<TCreateParameter> Builder { get; private set; }
        }

        private class ParameterBuilder : SubBuilderBase, ICreatingBuilder<TCreateParameter>
        {
            private readonly SqlParameter _sqlParameter;

            public ParameterBuilder(SqlCreateParameterBuilder<TCreateParameter> builder, SqlParameter sqlParameter)
                : base(builder)
            {
                _sqlParameter = sqlParameter;
            }

            public SqlCreateParameterBuilder<TCreateParameter> On(object parameterValue)
            {
                _sqlParameter.Value = parameterValue;
                Builder._model.AddParameter(_sqlParameter);
                return Builder;
            }

            public SqlCreateParameterBuilder<TCreateParameter> On()
            {
                Builder._model.AddParameter(_sqlParameter);
                return Builder;
            }
        }
    }
}