using Microsoft.AspNetCore.Mvc.Rendering;

namespace RiskAnalysis.WebUI.Helpers
{
    public static class EnumHelpers
    {
        public static List<SelectListItem> ToSelectList<T>(string? selectedValue = null) where T : Enum
        {
            var selectList = new List<SelectListItem>
            {
                new()
                {
                    Text = "Please select",
                    Value = string.Empty
                }
            };

            var enumList = Enum.GetValues(typeof(T))
                .Cast<T>()
                .Select(e => new SelectListItem
                {
                    Value = e.ToString(),
                    Text = e.ToString(),
                    Selected = selectedValue != null && e.ToString() == selectedValue
                }).ToList();

            selectList.AddRange(enumList);

            return selectList;
        }
    }
}
