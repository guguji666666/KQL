﻿using System;
using System.Collections.Generic;

namespace Kusto.Language.Binding
{
    using Symbols;
    using Utils;

    /// <summary>
    /// Binding state that persists across multiple bindings (lifetime of <see cref="KustoCache"/>)
    /// </summary>
    internal class GlobalBindingCache
    {
        internal readonly Dictionary<IReadOnlyList<TableSymbol>, TableSymbol> UnifiedNameColumnsMap =
            new Dictionary<IReadOnlyList<TableSymbol>, TableSymbol>(ReadOnlyListComparer<TableSymbol>.Default);

        internal readonly Dictionary<IReadOnlyList<TableSymbol>, TableSymbol> UnifiedNameAndTypeColumnsMap =
            new Dictionary<IReadOnlyList<TableSymbol>, TableSymbol>(ReadOnlyListComparer<TableSymbol>.Default);

        internal readonly Dictionary<IReadOnlyList<TableSymbol>, TableSymbol> CommonColumnsMap =
            new Dictionary<IReadOnlyList<TableSymbol>, TableSymbol>(ReadOnlyListComparer<TableSymbol>.Default);

        internal Dictionary<CallSiteInfo, Expansion> CallSiteToExpansionMap =
            new Dictionary<CallSiteInfo, Expansion>(CallSiteInfo.Comparer.Instance);
    }
}