using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections.Generic;

namespace DTValidator.TestIgnore {
    public class IgnoredOutletComponent : MonoBehaviour {
        public GameObject Outlet;
    }
}

namespace DTValidator.Internal {
    using DTValidator.TestIgnore;

    public static class ValidatorIgnoredNamespaceTests {
        private static IList<ValidatorIgnoredNamespace> IgnoredOutletComponentNamespaceProvider() {
            var ignoredNamespace = ScriptableObject.CreateInstance<ValidatorIgnoredNamespace>();
            ignoredNamespace.Namespace = "DTValidator.TestIgnore";

            return new ValidatorIgnoredNamespace[] { ignoredNamespace };
        }

        [Test]
        public static void IgnoredMissingOutlet_ReturnsNoErrors() {
            ValidatorIgnoredNamespaceProvider.SetCurrentProvider(IgnoredOutletComponentNamespaceProvider);
            ValidatorWhitelistedNamespaceProvider.SetCurrentProvider(() => new ValidatorWhitelistedNamespace[0]);
            ValidatorBlacklistedClassProvider.SetCurrentProvider(() => new ValidatorBlacklistedClass[0]);

            GameObject gameObject = new GameObject();

            var outletComponent = gameObject.AddComponent<IgnoredOutletComponent>();
            outletComponent.Outlet = null;

            IList<IValidationError> errors = Validator.Validate(gameObject);
            Assert.That(errors, Is.Null);

            ValidatorIgnoredNamespaceProvider.ClearCurrentProvider();
            ValidatorWhitelistedNamespaceProvider.ClearCurrentProvider();
            ValidatorBlacklistedClassProvider.ClearCurrentProvider();
        }
    }
}
