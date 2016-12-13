namespace PVT.Shop.Infrastructure.Common.Comparer
{
    using System.Collections.Generic;

    public class PropertyComparer : IEqualityComparer<Property>
    {
        public bool Equals
            (Property x,
             Property y)
        {
            //Check whether the compared objects reference the same data.
            if (ReferenceEquals(x, y))
            {
                return true;
            }

            //Check whether any of the compared objects is null.
            if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
            {
                return false;
            }

            //Check whether the property id and names are equal.
            return x.Id == y.Id;
        }

        // If Equals() returns true for a pair of objects 
        // then GetHashCode() must return the same value for these objects.

        public int GetHashCode
            (Property property)
        {
            //Check whether the object is null
            if (ReferenceEquals(property, null))
            {
                return 0;
            }

            //Get hash code for the Code field.
            var hashPropertyId = property.Id.GetHashCode();

            //Calculate the hash code for the product.
            return hashPropertyId;
        }
    }
}