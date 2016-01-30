using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using SurveyMonkey.Converters;

namespace SurveyMonkey
{
    public static class EnumRenameMap
    {
        private class mappingEnum
        {
            public string enumTypeName { get; set; }
            public string enumValueName { get; set; }
            public string mappedName { get; set; }
        }

        private static List<mappingEnum> mapList = new List<mappingEnum>();

        /// <summary>
        /// Used to map the enums to the correct string value in the json file.  Also used to map the json string value 
        /// back to the enum value.  This is one of the most tricky parts of the library.  Requries things stay in sync.
        /// Things being the enum name, enum value name and the survey monkey api string value.
        /// </summary>
        static EnumRenameMap()
        {
            // QuestionSubtypeEnum
            mapList.Add(new mappingEnum { enumTypeName = "QuestionSubtypeEnum", enumValueName = "Menu", mappedName = "menu" });
            mapList.Add(new mappingEnum { enumTypeName = "QuestionSubtypeEnum", enumValueName = "Vertical", mappedName = "vertical" });
            mapList.Add(new mappingEnum { enumTypeName = "QuestionSubtypeEnum", enumValueName = "VerticalTwoCol", mappedName = "vertical_two_col" });
            mapList.Add(new mappingEnum { enumTypeName = "QuestionSubtypeEnum", enumValueName = "VerticalThreeCol", mappedName = "vertical_three_col" });
            mapList.Add(new mappingEnum { enumTypeName = "QuestionSubtypeEnum", enumValueName = "Horizontal", mappedName = "horiz" });
            mapList.Add(new mappingEnum { enumTypeName = "QuestionSubtypeEnum", enumValueName = "Ranking", mappedName = "ranking" });
            mapList.Add(new mappingEnum { enumTypeName = "QuestionSubtypeEnum", enumValueName = "Rating", mappedName = "rating" });
            mapList.Add(new mappingEnum { enumTypeName = "QuestionSubtypeEnum", enumValueName = "Single", mappedName = "single" });
            mapList.Add(new mappingEnum { enumTypeName = "QuestionSubtypeEnum", enumValueName = "MultipleResponse", mappedName = "multi" });
            mapList.Add(new mappingEnum { enumTypeName = "QuestionSubtypeEnum", enumValueName = "Essay", mappedName = "essay" });
            mapList.Add(new mappingEnum { enumTypeName = "QuestionSubtypeEnum", enumValueName = "International", mappedName = "international" });
            mapList.Add(new mappingEnum { enumTypeName = "QuestionSubtypeEnum", enumValueName = "US", mappedName = "us" });
            mapList.Add(new mappingEnum { enumTypeName = "QuestionSubtypeEnum", enumValueName = "Both", mappedName = "both" });
            mapList.Add(new mappingEnum { enumTypeName = "QuestionSubtypeEnum", enumValueName = "DateOnly", mappedName = "date_only" });
            mapList.Add(new mappingEnum { enumTypeName = "QuestionSubtypeEnum", enumValueName = "TimeOnly", mappedName = "time_only" });
            mapList.Add(new mappingEnum { enumTypeName = "QuestionSubtypeEnum", enumValueName = "DescriptiveText", mappedName = "descriptive_text" });
            mapList.Add(new mappingEnum { enumTypeName = "QuestionSubtypeEnum", enumValueName = "Image", mappedName = "image" });
            mapList.Add(new mappingEnum { enumTypeName = "QuestionSubtypeEnum", enumValueName = "Numerical", mappedName = "numerical" });

            // QuestionFamilyEnum
            mapList.Add(new mappingEnum { enumTypeName = "QuestionFamilyEnum", enumValueName = "SingleChoice", mappedName = "single_choice" });
            mapList.Add(new mappingEnum { enumTypeName = "QuestionFamilyEnum", enumValueName = "MultipleChoice", mappedName = "multiple_choice" });
            mapList.Add(new mappingEnum { enumTypeName = "QuestionFamilyEnum", enumValueName = "Matrix", mappedName = "matrix" });
            mapList.Add(new mappingEnum { enumTypeName = "QuestionFamilyEnum", enumValueName = "OpenEnded", mappedName = "open_ended" });
            mapList.Add(new mappingEnum { enumTypeName = "QuestionFamilyEnum", enumValueName = "DateTime", mappedName = "datetime" });
            mapList.Add(new mappingEnum { enumTypeName = "QuestionFamilyEnum", enumValueName = "Presentation", mappedName = "presentation" });
            mapList.Add(new mappingEnum { enumTypeName = "QuestionFamilyEnum", enumValueName = "Demographic", mappedName = "demographic" });

            // AnswerTypeEnum
            mapList.Add(new mappingEnum { enumTypeName = "AnswerTypeEnum", enumValueName = "Row", mappedName = "row" });
            mapList.Add(new mappingEnum { enumTypeName = "AnswerTypeEnum", enumValueName = "Column", mappedName = "col" });
            mapList.Add(new mappingEnum { enumTypeName = "AnswerTypeEnum", enumValueName = "Other", mappedName = "other" });
            mapList.Add(new mappingEnum { enumTypeName = "AnswerTypeEnum", enumValueName = "Image", mappedName = "img" });
            mapList.Add(new mappingEnum { enumTypeName = "AnswerTypeEnum", enumValueName = "Label", mappedName = "label" });
            mapList.Add(new mappingEnum { enumTypeName = "AnswerTypeEnum", enumValueName = "Name", mappedName = "name" });
            mapList.Add(new mappingEnum { enumTypeName = "AnswerTypeEnum", enumValueName = "Company", mappedName = "company" });
            mapList.Add(new mappingEnum { enumTypeName = "AnswerTypeEnum", enumValueName = "Address", mappedName = "address" });
            mapList.Add(new mappingEnum { enumTypeName = "AnswerTypeEnum", enumValueName = "Address2", mappedName = "address2" });
            mapList.Add(new mappingEnum { enumTypeName = "AnswerTypeEnum", enumValueName = "City", mappedName = "city" });
            mapList.Add(new mappingEnum { enumTypeName = "AnswerTypeEnum", enumValueName = "State", mappedName = "state" });
            mapList.Add(new mappingEnum { enumTypeName = "AnswerTypeEnum", enumValueName = "Zip", mappedName = "zip" });
            mapList.Add(new mappingEnum { enumTypeName = "AnswerTypeEnum", enumValueName = "Country", mappedName = "country" });
            mapList.Add(new mappingEnum { enumTypeName = "AnswerTypeEnum", enumValueName = "Email", mappedName = "email" });
            mapList.Add(new mappingEnum { enumTypeName = "AnswerTypeEnum", enumValueName = "Phone", mappedName = "phone" });

            // CollectorTypeEnum
            mapList.Add(new mappingEnum { enumTypeName = "CollectorTypeEnum", enumValueName = "Url", mappedName = "url" });
            mapList.Add(new mappingEnum { enumTypeName = "CollectorTypeEnum", enumValueName = "Embedded", mappedName = "embedded" });
            mapList.Add(new mappingEnum { enumTypeName = "CollectorTypeEnum", enumValueName = "Email", mappedName = "email" });
            mapList.Add(new mappingEnum { enumTypeName = "CollectorTypeEnum", enumValueName = "Facebook", mappedName = "facebook" });
            mapList.Add(new mappingEnum { enumTypeName = "CollectorTypeEnum", enumValueName = "WebLink", mappedName = "weblink" });
            mapList.Add(new mappingEnum { enumTypeName = "CollectorTypeEnum", enumValueName = "Audience", mappedName = "audience" });

            // RespondentCollectionModeEnum
            mapList.Add(new mappingEnum { enumTypeName = "RespondentCollectionModeEnum", enumValueName = "Normal", mappedName = "normal" });
            mapList.Add(new mappingEnum { enumTypeName = "RespondentCollectionModeEnum", enumValueName = "Manual", mappedName = "manual" });
            mapList.Add(new mappingEnum { enumTypeName = "RespondentCollectionModeEnum", enumValueName = "SurveyPreview", mappedName = "survey_preview" });
            mapList.Add(new mappingEnum { enumTypeName = "RespondentCollectionModeEnum", enumValueName = "Edited", mappedName = "edited" });

            // RespondentStatusEnum
            mapList.Add(new mappingEnum { enumTypeName = "RespondentStatusEnum", enumValueName = "Completed", mappedName = "completed" });
            mapList.Add(new mappingEnum { enumTypeName = "RespondentStatusEnum", enumValueName = "Partial", mappedName = "partial" });
            mapList.Add(new mappingEnum { enumTypeName = "RespondentStatusEnum", enumValueName = "Disqualified", mappedName = "disqualified" });
            
        }

        public static Type GetEnumObject(string EnumName)
        {
            Type EnumType = null;

            if (EnumName == typeof(QuestionFamilyEnum).Name)
            {
                EnumType = typeof(QuestionFamilyEnum);
            }
            else if (EnumName == typeof(QuestionSubtypeEnum).Name)
            {
                EnumType = typeof(QuestionSubtypeEnum);
            }
            else if (EnumName == typeof(AnswerTypeEnum).Name)
            {
                EnumType = typeof(AnswerTypeEnum);
            }
            else if (EnumName == typeof(CollectorTypeEnum).Name)
            {
                EnumType = typeof(CollectorTypeEnum);
            }
            else if (EnumName == typeof(RespondentCollectionModeEnum).Name)
            {
                EnumType = typeof(RespondentCollectionModeEnum);
            }
            else if (EnumName == typeof(RespondentStatusEnum).Name)
            {
                EnumType = typeof(RespondentStatusEnum);
            }
            else if (EnumName == typeof(RespondentListSortEnum).Name)
            {
                EnumType = typeof(RespondentListSortEnum);
            }

            return EnumType;
        }

        public static string MappedName(string enumTypeName, string enumValueName)
        {
            string mappedValue = mapList.Where(e => e.enumTypeName == enumTypeName && e.enumValueName == enumValueName).Select(e => e.mappedName).FirstOrDefault();
            if (mappedValue == null)
            {
                mappedValue = enumValueName;
            }

            return mappedValue;
        }

        public static string MappedValue(string enumTypeName, string mappedName)
        {
            string enumValueName = null;
            if (mappedName != null)
            {
                enumValueName = mapList.Where(e => e.enumTypeName == enumTypeName && e.mappedName == mappedName).Select(e => e.enumValueName).FirstOrDefault();
                if (enumValueName == null)
                {
                    enumValueName = mappedName;
                }
            }

            if (enumValueName == null)
            {
                enumValueName = "NotSet";
            }

            return enumValueName;
        }
    }

    [JsonConverter(typeof(DefaultEnumMapConverter))]
    public enum QuestionFamilyEnum
    {
        NotSet = 0,
        SingleChoice,
        MultipleChoice,
        Matrix,
        OpenEnded,
        Demographic,
        DateTime,
        Presentation,
        CustomVariable
    }

    [JsonConverter(typeof(DefaultEnumMapConverter))]
    public enum QuestionSubtypeEnum
    {
        NotSet = 0,
        Menu,
        Vertical,
        VerticalTwoCol,
        VerticalThreeCol,
        Horizontal,
        Ranking,
        Rating,
        Single,
        MultipleResponse,
        Essay,
        International,
        US,
        Both,
        DateOnly,
        TimeOnly,
        DescriptiveText,
        Image,
        Numerical,
        CustomVariable
    }

    [JsonConverter(typeof(DefaultEnumMapConverter))]
    public enum AnswerTypeEnum
    {
        NotSet = 0,
        Row,
        Column,
        Other,
        Image,
        Label,
        Name,
        Company,
        Address,
        Address2,
        City,
        State,
        Zip,
        Country,
        Email,
        Phone
    }

    [JsonConverter(typeof(DefaultEnumMapConverter))]
    public enum RankTypeEnum
    {
        NotSet = 0,
        AvgRating,
        AvgRanking,
        PercentOfResponses,
        PercentFilledOut
    }

    [JsonConverter(typeof(DefaultEnumMapConverter))]
    public enum CollectorTypeEnum
    {
        NotSet = 0,
        Url,
        Embedded,
        Email,
        Facebook,
        WebLink,
        Audience
    }

    [JsonConverter(typeof(DefaultEnumMapConverter))]
    public enum RespondentCollectionModeEnum
    {
        NotSet = 0,
        Normal,
        Manual,
        SurveyPreview,
        Edited
    }

    [JsonConverter(typeof(DefaultEnumMapConverter))]
    public enum RespondentStatusEnum
    {
        NotSet = 0,
        Completed,
        Partial,
        Disqualified
    }

    [JsonConverter(typeof(DefaultEnumMapConverter))]
    public enum RespondentListSortEnum
    {
        NotSet = 0,
        RespondentID,
        DateModified,
        DateStart
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum LanguageEnum
    {
        NotSet = 0,
        English = 1,
        ChineseSimplified = 2,
        ChineseTraditional = 3,
        Danish = 4,
        Dutch = 5,
        Finnish = 6,
        French = 7,
        German = 8,
        Greek = 9,
        Italian = 10,
        Japanese = 11,
        Korean = 12,
        Malay = 13,
        Norwegian = 14,
        Polish = 15,
        PortugueseIberian = 16,
        PortugueseBrazilian = 17,
        Russian = 18,
        Spanish = 19,
        Swedish = 20,
        Turkish = 21,
        Ukrainian = 22,
        Reverse = 23,
        Albanian = 24,
        Arabic = 25,
        Armenian = 26,
        Basque = 27,
        Bengali = 28,
        Bosnian = 29,
        Bulgarian = 30,
        Catalan = 31,
        Croatian = 32,
        Czech = 33,
        Estonian = 34,
        Filipino = 35,
        Georgian = 36,
        Hebrew = 37,
        Hindi = 38,
        Hungarian = 39,
        Icelandic = 40,
        Indonesian = 41,
        Irish = 42,
        Kurdish = 43,
        Latvian = 44,
        Lithuanian = 45,
        Macedonian = 46,
        Malayalam = 47,
        Persian = 48,
        Punjabi = 49,
        Romanian = 50,
        Serbian = 51,
        Slovak = 52,
        Slovenian = 53,
        Swahili = 54,
        Tamil = 55,
        Telugu = 56,
        Thai = 57,
        Vietnamese = 58,
        Welsh = 59
    }
}
