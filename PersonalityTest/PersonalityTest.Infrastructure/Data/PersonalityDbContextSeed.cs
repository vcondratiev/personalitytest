using Microsoft.Extensions.Logging;
using PersonalityTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalityTest.Infrastructure.Data
{
    public class PersonalityDbContextSeed
    {
        public async Task SeedAsync(PersonalityDbContext context, ILogger<PersonalityDbContextSeed> logger)
        {
            if (!context.QuestionSets.Any())
            {
                context.QuestionSets.AddRange(GetDefaultQuestionSets());
                await context.SaveChangesAsync();
            }
        }

        private IEnumerable<QuestionSet> GetDefaultQuestionSets() => new List<QuestionSet>
        {
            new QuestionSet
            {
                Id = Guid.Parse("384eebbc-0516-4233-91f8-dbcee11c0f3e"),
                Description = "So do you consider yourself more of an introvert or an extrovert? Take this test, put together with input from psychoanalyst Sandrine Dury, and find out",
                Name = "Personality Test",
                Order = 1,
                Questions = new List<Question>
                {
                    new Question
                    {
                        Id = Guid.NewGuid(),
                        Order = 1,
                        Title = "You’re really busy at work and a colleague is telling you their life story and personal woes. You:",
                        QuestionOptions = new List<QuestionOption>
                        {
                            new QuestionOption
                            {
                                Id = Guid.NewGuid(),
                                Text = "Don’t dare to interrupt them",
                                 Value = "1"
                            },
                            new QuestionOption
                            {
                                Id = Guid.NewGuid(),
                                Text = "Think it’s more important to give them some of your time; work can wait",
                                Value = "2"
                            },
                            new QuestionOption
                            {
                                Id = Guid.NewGuid(),
                                Text = "Listen, but with only with half an ear",
                                Value = "3"
                            },
                            new QuestionOption
                            {
                                Id = Guid.NewGuid(),
                                Text = "Interrupt and explain that you are really busy at the moment",
                                Value = "4"
                            }
                        }
                    },
                    new Question
                    {
                        Id = Guid.NewGuid(),
                        Order = 1,
                        Title = "You’ve been sitting in the doctor’s waiting room for more than 25 minutes. You:",
                        QuestionOptions = new List<QuestionOption>
                        {
                            new QuestionOption
                            {
                                Id = Guid.NewGuid(),
                                Text = "Look at your watch every two minutes",
                                 Value = "1"
                            },
                            new QuestionOption
                            {
                                Id = Guid.NewGuid(),
                                Text = "Bubble with inner anger, but keep quiet",
                                Value = "2"
                            },
                            new QuestionOption
                            {
                                Id = Guid.NewGuid(),
                                Text = "Explain to other equally impatient people in the room that the doctor is always running late",
                                Value = "3"
                            },
                            new QuestionOption
                            {
                                Id = Guid.NewGuid(),
                                Text = "Complain in a loud voice, while tapping your foot impatiently",
                                Value = "4"
                            }
                        }
                    },
                    new Question
                    {
                        Id = Guid.NewGuid(),
                        Order = 1,
                        Title = "You’re having an animated discussion with a colleague regarding a project that you’re in charge of. You:",
                        QuestionOptions = new List<QuestionOption>
                        {
                            new QuestionOption
                            {
                                Id = Guid.NewGuid(),
                                Text = "Don’t dare contradict them",
                                 Value = "1"
                            },
                            new QuestionOption
                            {
                                Id = Guid.NewGuid(),
                                Text = "Think that they are obviously right",
                                Value = "2"
                            },
                            new QuestionOption
                            {
                                Id = Guid.NewGuid(),
                                Text = "Defend your own point of view, tooth and nail",
                                Value = "3"
                            },
                            new QuestionOption
                            {
                                Id = Guid.NewGuid(),
                                Text = "Continuously interrupt your colleague",
                                Value = "4"
                            }
                        }
                    },
                    new Question
                    {
                        Id = Guid.NewGuid(),
                        Order = 1,
                        Title = "You are taking part in a guided tour of a museum. You:",
                        QuestionOptions = new List<QuestionOption>
                        {
                            new QuestionOption
                            {
                                Id = Guid.NewGuid(),
                                Text = "Are a bit too far towards the back so don’t really hear what the guide is saying",
                                 Value = "1"
                            },
                            new QuestionOption
                            {
                                Id = Guid.NewGuid(),
                                Text = "Follow the group without question",
                                 Value = "2"
                            },
                            new QuestionOption
                            {
                                Id = Guid.NewGuid(),
                                Text = "Make sure that everyone is able to hear properly",
                                 Value = "3"
                            },
                            new QuestionOption
                            {
                                Id = Guid.NewGuid(),
                                Text = "Are right up the front, adding your own comments in a loud voice",
                                 Value = "4"
                            }
                        }
                    },
                    new Question
                    {
                        Id = Guid.NewGuid(),
                        Order = 1,
                        Title = "During dinner parties at your home, you have a hard time with people who:",
                        QuestionOptions = new List<QuestionOption>
                        {
                            new QuestionOption
                            {
                                Id = Guid.NewGuid(),
                                Text = "Ask you to tell a story in front of everyone else",
                                Value = "1"
                            },
                            new QuestionOption
                            {
                                Id = Guid.NewGuid(),
                                Text = "Talk privately between themselves",
                                Value = "2"
                            },
                            new QuestionOption
                            {
                                Id = Guid.NewGuid(),
                                Text = "Hang around you all evening",
                                Value = "3"
                            },
                            new QuestionOption
                            {
                                Id = Guid.NewGuid(),
                                Text = "Always drag the conversation back to themselves",
                                Value = "4"
                            }
                        }
                    },
                    new Question
                    {
                        Id = Guid.NewGuid(),
                        Order = 1,
                        Title = "You crack a joke at work, but nobody seems to have noticed. You:",
                        QuestionOptions = new List<QuestionOption>
                        {
                            new QuestionOption
                            {
                                Id = Guid.NewGuid(),
                                Text = "Think it’s for the best — it was a lame joke anyway",
                                Value = "1"
                            },
                            new QuestionOption
                            {
                                Id = Guid.NewGuid(),
                                Text = "Wait to share it with your friends after work",
                                Value = "2"
                            },
                            new QuestionOption
                            {
                                Id = Guid.NewGuid(),
                                Text = "Try again a bit later with one of your colleagues",
                                Value = "3"
                            },
                            new QuestionOption
                            {
                                Id = Guid.NewGuid(),
                                Text = "Keep telling it until they pay attention",
                                Value = "4"
                            }
                        }
                    },
                    new Question
                    {
                        Id = Guid.NewGuid(),
                        Order = 1,
                        Title = "This morning, your agenda seems to be free. You:",
                        QuestionOptions = new List<QuestionOption>
                        {
                            new QuestionOption
                            {
                                Id = Guid.NewGuid(),
                                Text = "Know that somebody will find a reason to come and bother you",
                                Value = "1"
                            },
                            new QuestionOption
                            {
                                Id = Guid.NewGuid(),
                                Text = "Heave a sigh of relief and look forward to a day without stress",
                                Value = "2"
                            },
                            new QuestionOption
                            {
                                Id = Guid.NewGuid(),
                                Text = "Question your colleagues about a project that’s been worrying you",
                                Value = "3"
                            },
                            new QuestionOption
                            {
                                Id = Guid.NewGuid(),
                                Text = "Pick up the phone and start filling up your agenda with meetings",
                                Value = "4"
                            }
                        }
                    },
                    new Question
                    {
                        Id = Guid.NewGuid(),
                        Order = 1,
                        Title = "During dinner, the discussion moves to a subject about which you know nothing at all. You:",
                        QuestionOptions = new List<QuestionOption>
                        {
                            new QuestionOption
                            {
                                Id = Guid.NewGuid(),
                                Text = "Don’t dare show that you don’t know anything about the subject",
                                Value = "1"
                            },
                            new QuestionOption
                            {
                                Id = Guid.NewGuid(),
                                Text = "Barely follow the discussion",
                                Value = "2"
                            },
                            new QuestionOption
                            {
                                Id = Guid.NewGuid(),
                                Text = "Ask lots of questions to learn more about it",
                                Value = "3"
                            },
                            new QuestionOption
                            {
                                Id = Guid.NewGuid(),
                                Text = "Change the subject of discussion",
                                Value = "4"
                            }
                        }
                    },
                    new Question
                    {
                        Id = Guid.NewGuid(),
                        Order = 1,
                        Title = "You’re out with a group of friends and there’s a person who’s quite shy and doesn’t talk much. You:",
                        QuestionOptions = new List<QuestionOption>
                        {
                            new QuestionOption
                            {
                                Id = Guid.NewGuid(),
                                Text = "Notice that they’re alone, but don’t go over to talk with them",
                                Value = "1"
                            },
                            new QuestionOption
                            {
                                Id = Guid.NewGuid(),
                                Text = "Go and have a chat with them",
                                Value = "2"
                            },
                            new QuestionOption
                            {
                                Id = Guid.NewGuid(),
                                Text = "Shoot some friendly smiles in their direction",
                                Value = "3"
                            },
                            new QuestionOption
                            {
                                Id = Guid.NewGuid(),
                                Text = "Hardly notice them at all",
                                Value = "4"
                            }
                        }
                    },
                    new Question
                    {
                        Id = Guid.NewGuid(),
                        Order = 1,
                        Title = "At work, somebody asks for your help for the hundredth time. You:",
                        QuestionOptions = new List<QuestionOption>
                        {
                            new QuestionOption
                            {
                                Id = Guid.NewGuid(),
                                Text = "Give them a hand, as usual",
                                Value = "1"
                            },
                            new QuestionOption
                            {
                                Id = Guid.NewGuid(),
                                Text = "Accept — you’re known for being helpful",
                                Value = "2"
                            },
                            new QuestionOption
                            {
                                Id = Guid.NewGuid(),
                                Text = "Ask them, please, to find somebody else for a change",
                                Value = "3"
                            },
                            new QuestionOption
                            {
                                Id = Guid.NewGuid(),
                                Text = "Loudly make it known that you’re annoyed",
                                Value = "4"
                            }
                        }
                    }
                }
            }
        };
    }
}
