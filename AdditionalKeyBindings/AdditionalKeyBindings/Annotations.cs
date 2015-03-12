﻿using System;
using System.Diagnostics;

namespace AdditionalKeyBindings
{
	[Flags]
	public enum ImplicitUseKindFlags
	{
		Default = Access | Assign | InstantiatedWithFixedConstructorSignature,
		/// <summary>Only entity marked with attribute considered used</summary>
		Access = 1,
		/// <summary>Indicates implicit assignment to a member</summary>
		Assign = 2,
		/// <summary>
		/// Indicates implicit instantiation of a type with fixed constructor signature.
		/// That means any unused constructor parameters won't be reported as such.
		/// </summary>
		InstantiatedWithFixedConstructorSignature = 4,
		/// <summary>Indicates implicit instantiation of a type</summary>
		InstantiatedNoFixedConstructorSignature = 8,
	}

	[Flags]
	public enum ImplicitUseTargetFlags
	{
		Default = Itself,
		Itself = 1,
		/// <summary>Members of entity marked with attribute are considered used</summary>
		Members = 2,
		/// <summary>Entity marked with attribute and all its members considered used</summary>
		WithMembers = Itself | Members
	}

	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Parameter | AttributeTargets.Property | AttributeTargets.Delegate | AttributeTargets.Field | AttributeTargets.Event)]
	[Conditional("DEBUG")]
	public sealed class CanBeNullAttribute : Attribute { }

	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Parameter | AttributeTargets.Property | AttributeTargets.Delegate | AttributeTargets.Field | AttributeTargets.Event)]
	[Conditional("DEBUG")]
	public sealed class NotNullAttribute : Attribute { }

	[AttributeUsage(AttributeTargets.All)]
	[Conditional("DEBUG")]
	public sealed class UsedImplicitlyAttribute : Attribute
	{
		public UsedImplicitlyAttribute()
			: this(ImplicitUseKindFlags.Default, ImplicitUseTargetFlags.Default) { }

		public UsedImplicitlyAttribute(ImplicitUseKindFlags useKindFlags)
			: this(useKindFlags, ImplicitUseTargetFlags.Default) { }

		public UsedImplicitlyAttribute(ImplicitUseTargetFlags targetFlags)
			: this(ImplicitUseKindFlags.Default, targetFlags) { }

		public UsedImplicitlyAttribute(
		  ImplicitUseKindFlags useKindFlags, ImplicitUseTargetFlags targetFlags)
		{
			UseKindFlags = useKindFlags;
			TargetFlags = targetFlags;
		}

		public ImplicitUseKindFlags UseKindFlags { get; private set; }
		public ImplicitUseTargetFlags TargetFlags { get; private set; }

	}
}