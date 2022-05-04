namespace ClearMeasure.Palermo.Core.Lists;

public class ExpenseReportStatus
{
	private static ExpenseReportStatus None = new ExpenseReportStatus("", "", " ", 0);
	public static ExpenseReportStatus Draft => new ExpenseReportStatus("DFT", "Draft", "Drafting", 1);
	public static ExpenseReportStatus Submitted => new ExpenseReportStatus("SBM", "Submitted", "Submitted", 2);
	public static ExpenseReportStatus Approved => new ExpenseReportStatus("APV", "Approved", "Approved", 3);
	public static ExpenseReportStatus Cancelled => new ExpenseReportStatus("CAN", "Cancelled", "Cancelled", 4);

	private readonly string _code;
	private readonly string _key;
	private string _friendlyName;
	private readonly byte _sortBy;
	private ExpenseReportStatus _innerStatus = None;
    private static HashSet<ExpenseReportStatus> _extensions = new HashSet<ExpenseReportStatus>();

	public ExpenseReportStatus()
	{
	}

	public ExpenseReportStatus(string code, string key, string friendlyName, byte sortBy)
	{
		_code = code;
		_key = key;
		_friendlyName = friendlyName;
		_sortBy = sortBy;
		_innerStatus = this;
	}

	public static ExpenseReportStatus[] GetAllItems()
    {
        var allItems = new[]
        {
            Draft,
            Submitted,
            Approved,
            Cancelled
        };

        return allItems.Concat(_extensions).ToArray();
    }

	public string Code
	{
		get
		{
			return _innerStatus._code;
		}

		set
		{
			_innerStatus = FromCode(value);
		}
	}

	public string Key
	{
		get { return _innerStatus._key; }
	}

	public string FriendlyName
	{
		get { return _innerStatus._friendlyName; }
        set { _friendlyName = value; }
    }

	public byte SortBy
	{
		get
		{
			return _innerStatus._sortBy;
		}
	}

	public override bool Equals(object obj)
	{
		var code = obj as ExpenseReportStatus;
		if (code == null) return false;

		if (!GetType().Equals(obj.GetType())) return false;

		return Code.Equals(code.Code, StringComparison.InvariantCulture);
	}

	public override string ToString()
	{
		return FriendlyName;
	}

	public override int GetHashCode()
	{
		return Code.GetHashCode();
	}

	public ExpenseReportStatus Clone()
	{
		return FromCode(_code);
	}

	public bool IsEmpty()
	{
		return string.IsNullOrEmpty(Code);
	}

	public static ExpenseReportStatus FromCode(string code)
	{
		ExpenseReportStatus[] items = GetAllItems();
		ExpenseReportStatus match =
			Array.Find(items, delegate (ExpenseReportStatus instance) { return instance._code == code; });

		if (match == null)
		{
			match = None;
		}

		return match;
	}

	public static ExpenseReportStatus FromKey(string key)
	{
		if (key == null)
		{
			throw new NotSupportedException("Finding a ExpenseReportStatus for a null key is not supported");
		}

		ExpenseReportStatus[] items = GetAllItems();
		ExpenseReportStatus match = Array.Find(items, delegate (ExpenseReportStatus instance) { return (instance.Key.Equals(key, StringComparison.InvariantCultureIgnoreCase)); });

		if (match == null)
		{
			throw new ArgumentOutOfRangeException($"Key '{key}' is not a valid key for {typeof(ExpenseReportStatus).Name}");
		}

		return match;
	}

	public static ExpenseReportStatus Parse(string name)
	{
		return FromKey(name);
	}

#pragma warning disable CA2225 // Operator overloads have named alternates
	public static implicit operator ExpenseReportStatus(string code)
#pragma warning restore CA2225 // Operator overloads have named alternates
	{
		return FromCode(code);
	}

	public void Change(ExpenseReportStatus expenseReportStatus)
	{
		_innerStatus = expenseReportStatus;
	}

    public static void LoadExtensions(IEnumerable<ExpenseReportStatus> statuses)
    {
        foreach (var status in statuses)
        {
            _extensions.Add(status);
        }
    }

}