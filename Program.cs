using System.Reflection.Metadata;

string[] spelomgångar = {"","","","","","","","","","","","","","","","","","","","",};

for(int såkandetvara = 0; såkandetvara != 20; såkandetvara++){
    List<string> kortlek = new List<string>{
        "Ess", "Ess", "Ess", "Ess", "2", "2", "2", "2", "3", "3", "3", "3",
        "4", "4", "4", "4", "5", "5", "5", "5", "6", "6", "6", "6",
        "7", "7", "7", "7", "8", "8", "8", "8", "9", "9", "9", "9",
        "10", "10", "10", "10", "Knäkt", "Knäkt", "Knäkt", "Knäkt",
        "Dam", "Dam", "Dam", "Dam", "Kung", "Kung", "Kung", "Kung"
    };

    /*  ändra tid på linje 17 och 296 till något heltal, det ändrar hastigheten av texten.
        ändra även if() på linje 78 till true om du vill spela */
    int poäng1 = 0;
    int poäng2 = 0;
    int poäng3 = 0;
    int poäng4 = 0;
    int fullpoäng = 0;

    int vemkör = 0;

    string[] aiminne = {"null","kuk1", "kuk2", "kuk3", "kuk4"};
    int smartareai = 1;

    int tid = 60;
    int föratt = 0;
    int frågavilken = 0;
    int handantalkort = 0;
    int vemdunyssfråga = 0;
    int spelareval = 0; //används bara för att veta vem de frågar kan nog sätta i en method
    string check = "nullll";

    Random r = new Random();

    int antalKortPerSpelare = 7;
    List<string> spelare1 = new List<string>{};
    List<string> spelare2 = new List<string>{};
    List<string> spelare3 = new List<string>{};
    List<string> spelare4 = new List<string>{};




    // Dela ut kort till spelare
    for (int i = 0; i < antalKortPerSpelare; i++){
        spelare1.Add(DraKort(kortlek, r));
        harde4(ref fullpoäng, ref spelare1, ref poäng1, ref check, vemkör);
        spelare2.Add(DraKort(kortlek, r));
        harde4(ref fullpoäng, ref spelare2, ref poäng2, ref check, vemkör);
        spelare3.Add(DraKort(kortlek, r));
        harde4(ref fullpoäng, ref spelare3, ref poäng3, ref check, vemkör);
        spelare4.Add(DraKort(kortlek, r));
        harde4(ref fullpoäng, ref spelare4, ref poäng4, ref check, vemkör);
    }

    // Skriv ut spelarnas händer
    string mes1 = "Du: ";
    string mes2 = "Spelare 2: ";
    string mes3 = "Spelare 3: ";
    string mes4 = "Spelare 4: ";

    sakta(mes1,tid);
        vadhardeförkort(spelare1);

    // ta bort dessa när du ska spela bara skriv /*
    /*
    sakta(mes2,tid);
        vadhardeförkort(spelare2);
    sakta(mes3,tid);
        vadhardeförkort(spelare3);
    sakta(mes4,tid);
        vadhardeförkort(spelare4);

    // och  hör för att ta veck dem eller radera dem.
    */


    string mes5 = ".";
    for(int i = 0; i != 4; i++){
        sakta(mes5,tid);
    }

    
    while(spelare1.Count != 0 && spelare2.Count != 0 && spelare3.Count != 0 && spelare4.Count != 0){
    //for(int bala = 0; bala != 10; bala++){  /* den är här för att fel söka när det hamnar i en oänlig loop*/ 
        //spelare 1
        vemkör = 1;

        if(spelare1.Count != 0){
            do{
                Console.WriteLine("Spelare 1 ");
                Console.WriteLine();
                ingakort(vemkör, ref kortlek, ref spelare1, r);

                if(1==1){
                    
                    do{
                        if(spelare1.Count == 0){
                            break;
                        }
                        
                        string mes6 = "Dina kort";
                        sakta(mes6,tid);
                        vadhardeförkort(spelare1);

                        string mes7 = "Vilket kort vill du ta";
                        sakta(mes7,tid);
                        string kortetduvillha = Console.ReadLine();
                        if(kortetduvillha == "knäkt"){
                            kortetduvillha = "Knäkt";
                        }
                        if(kortetduvillha == "dam"){
                            kortetduvillha = "Dam";
                        }
                        if(kortetduvillha == "kung"){
                            kortetduvillha = "Kung";
                        }
                        if(kortetduvillha == "ess"){
                            kortetduvillha = "Ess";
                        }
                        check = kortetduvillha;
                        if(!spelare1.Contains(check)){
                            string mes8 = "Du har inte det kortet, välj ett annat";
                            sakta(mes8, tid);
                        }
                    }while(!spelare1.Contains(check));
                    if(spelare1.Count == 0){
                        break;
                    }

                    do{
                        string mes9 = "Vem vill du fråga, spelare 2, 3 eller 4. Skriv 2, 3 eller 4";
                        sakta(mes9, tid);

                        frågavilken = int.Parse(Console.ReadLine());
                        if(frågavilken != 2 && frågavilken != 3 && frågavilken != 4){
                            string mes11 = "Det va inte 2, 3 eller 4";
                            sakta(mes11,tid);
                        }
                    }while(frågavilken != 2 && frågavilken != 3 && frågavilken != 4);
                    
                }
                else{
                    handantalkort = spelare1.Count;
                    if(handantalkort != 0){
                        check = spelare1[r.Next(0,handantalkort)];
                    }
                    
                    if(smartareai == 1){
                        åjaghardetkortet(vemkör, spelare1, aiminne, ref check, ref spelareval);
                    }
                    else{
                        aivälja(ref spelareval, vemkör, ref vemdunyssfråga);
                    }
                    smartareai++;

                    if(spelareval == 0 || spelareval == 1 || frågavilken == 0 || frågavilken == 1){
                        aivälja(ref spelareval, vemkör, ref vemdunyssfråga);
                    }
                    frågavilken = spelareval;
                }
                if(frågavilken == vemkör){
                    aivälja(ref spelareval, vemkör, ref vemdunyssfråga);
                    frågavilken = spelareval;
                }

                if(frågavilken == 2){
                    drakort_frånhand(frågavilken, ref spelare1, ref spelare2, check, ref föratt, vemkör);
                    vemdunyssfråga = 2;
                    harde4(ref fullpoäng, ref spelare1, ref poäng1, ref check, vemkör);
                }
                if(frågavilken == 3){
                    drakort_frånhand(frågavilken, ref spelare1, ref spelare3, check, ref föratt, vemkör);
                    vemdunyssfråga = 3;
                    harde4(ref fullpoäng, ref spelare1, ref poäng1, ref check, vemkör);
                }
                if(frågavilken == 4){
                    drakort_frånhand(frågavilken, ref spelare1, ref spelare4, check, ref föratt, vemkör);
                    vemdunyssfråga = 4;
                    harde4(ref fullpoäng, ref spelare1, ref poäng1, ref check, vemkör);
                }
                harde4(ref fullpoäng, ref spelare1, ref poäng1, ref check, vemkör);
                aiminne[vemkör] = check;
            }while(föratt == 1);
            smartareai = 1;
        }

        if(kortlek.Count != 0){
            spelare1.Add(DraKort(kortlek, r));
        }
        harde4(ref fullpoäng, ref spelare1, ref poäng1, ref check, vemkör);

        // spelare1 2
        vemkör = 2;
        //vilket kort de vill ha
        ingakort(vemkör, ref kortlek, ref spelare2, r);
        
        handantalkort = spelare2.Count;
        if(handantalkort != 0){
            check = spelare2[r.Next(0,handantalkort)];
        }

        //vilken spelare de frågar
        if(spelare2.Count != 0){
            do{
                Console.WriteLine("Spelare 2 ");
                Console.WriteLine();
                if(smartareai == 1){
                    åjaghardetkortet(vemkör, spelare2, aiminne, ref check, ref spelareval);
                }
                else{
                    aivälja(ref spelareval, vemkör, ref vemdunyssfråga);
                }
                smartareai++;
                if(spelareval == 0 || frågavilken == 0){
                    aivälja(ref spelareval, vemkör, ref vemdunyssfråga);
                }

                frågavilken = spelareval;

                if(frågavilken == vemkör){
                    aivälja(ref spelareval, vemkör, ref vemdunyssfråga);
                    frågavilken = spelareval;
                }


                if(frågavilken == 1){
                    drakort_frånhand(frågavilken, ref spelare2, ref spelare1, check, ref föratt, vemkör);
                    vemdunyssfråga = 1;
                    harde4(ref fullpoäng, ref spelare2, ref poäng2, ref check, vemkör);
                }
                if(frågavilken == 3){
                    drakort_frånhand(frågavilken, ref spelare2, ref spelare3, check, ref föratt, vemkör);
                    vemdunyssfråga = 3;
                    harde4(ref fullpoäng, ref spelare2, ref poäng2, ref check, vemkör);
                }
                if(frågavilken == 4){
                    drakort_frånhand(frågavilken, ref spelare2, ref spelare4, check, ref föratt, vemkör);
                    vemdunyssfråga = 4;
                    harde4(ref fullpoäng, ref spelare2, ref poäng2, ref check, vemkör);
                }
                harde4(ref fullpoäng, ref spelare2, ref poäng2, ref check, vemkör);
                aiminne[vemkör] = check;
            }while(föratt == 1);
            smartareai = 1;
        }

        if(kortlek.Count != 0){
            spelare2.Add(DraKort(kortlek, r));
        }
        harde4(ref fullpoäng, ref spelare2, ref poäng2, ref check, vemkör);

        // spelare 3
        vemkör = 3;
        //vilket kort de vill ha
        ingakort(vemkör, ref kortlek, ref spelare3, r);
        
        handantalkort = spelare3.Count;
        if(handantalkort != 0){
            check = spelare3[r.Next(0,handantalkort)];
        }


        

        //vilken spelare de frågar
        if(spelare3.Count != 0){
            do{
                Console.WriteLine("Spelare 3 ");
                Console.WriteLine();
                
                if(smartareai == 1){
                    åjaghardetkortet(vemkör, spelare3, aiminne, ref check, ref spelareval);
                }
                else{
                    aivälja(ref spelareval, vemkör, ref vemdunyssfråga);
                }
                smartareai++;
                if(spelareval == 0 || frågavilken == 0){
                    aivälja(ref spelareval, vemkör, ref vemdunyssfråga);
                }

                frågavilken = spelareval;
                if(frågavilken == vemkör){
                    aivälja(ref spelareval, vemkör, ref vemdunyssfråga);
                    frågavilken = spelareval;
                }

                if(frågavilken == 1){           
                    drakort_frånhand(frågavilken, ref spelare3, ref spelare1, check, ref föratt, vemkör);
                    vemdunyssfråga = 1;
                    harde4(ref fullpoäng, ref spelare3, ref poäng3, ref check, vemkör);
                }
                if(frågavilken == 2){
                    drakort_frånhand(frågavilken, ref spelare3, ref spelare2, check, ref föratt, vemkör);
                    vemdunyssfråga = 2;
                    harde4(ref fullpoäng, ref spelare3, ref poäng3, ref check, vemkör);
                }
                if(frågavilken == 4){
                    drakort_frånhand(frågavilken, ref spelare3, ref spelare4, check, ref föratt, vemkör);
                    vemdunyssfråga = 4;
                    harde4(ref fullpoäng, ref spelare3, ref poäng3, ref check, vemkör);
                }
                harde4(ref fullpoäng, ref spelare3, ref poäng3, ref check, vemkör);
                aiminne[vemkör] = check;
            }while(föratt == 1);
            smartareai = 1;
        }

        if(kortlek.Count != 0){
            spelare3.Add(DraKort(kortlek, r));
        }
        harde4(ref fullpoäng, ref spelare3, ref poäng3, ref check, vemkör);

        // spelare1 4
        vemkör = 4;
        //vilket kort de vill ha
        ingakort(vemkör, ref kortlek, ref spelare4, r);
        
        handantalkort = spelare4.Count;
        if(handantalkort != 0){
            
            check = spelare4[r.Next(0,handantalkort)];
        }

        //vilken spelare de frågar
        if(spelare4.Count != 0){
            
            do{
                Console.WriteLine("Spelare 4 ");
                Console.WriteLine();

                if(smartareai == 1){
                    åjaghardetkortet(vemkör,spelare4, aiminne, ref check, ref spelareval);
                }
                else{
                    aivälja(ref spelareval, vemkör, ref vemdunyssfråga);
                }
                smartareai++;
                if(spelareval == 0 || frågavilken == 0){
                    aivälja(ref spelareval, vemkör, ref vemdunyssfråga);
                }

                frågavilken = spelareval;
                if(frågavilken == vemkör){
                    aivälja(ref spelareval, vemkör, ref vemdunyssfråga);
                    frågavilken = spelareval;
                }


                if(frågavilken == 1){           
                    drakort_frånhand(frågavilken, ref spelare4, ref spelare1, check, ref föratt, vemkör);
                    vemdunyssfråga = 1;
                    harde4(ref fullpoäng, ref spelare4, ref poäng4, ref check, vemkör);
                }
                if(frågavilken == 2){
                    drakort_frånhand(frågavilken, ref spelare4, ref spelare2, check, ref föratt, vemkör);
                    vemdunyssfråga = 2;
                    harde4(ref fullpoäng, ref spelare4, ref poäng4, ref check, vemkör);
                }
                if(frågavilken == 3){
                    drakort_frånhand(frågavilken, ref spelare4, ref spelare3, check, ref föratt, vemkör);
                    vemdunyssfråga = 3;
                    harde4(ref fullpoäng, ref spelare4, ref poäng4, ref check, vemkör);
                }
                harde4(ref fullpoäng, ref spelare4, ref poäng4, ref check, vemkör);
                aiminne[vemkör] = check;
            }while(föratt == 1);
            smartareai = 1;
        }

        if(kortlek.Count != 0){
            spelare4.Add(DraKort(kortlek, r));
        }
        harde4(ref fullpoäng, ref spelare4, ref poäng4, ref check, vemkör);
    }

    sakta(mes1,tid);
        Console.WriteLine(poäng1 + " poäng");
        Console.WriteLine();
    sakta(mes2,tid);
        Console.WriteLine(poäng2 + " poäng");
        Console.WriteLine();
    sakta(mes3,tid);
        Console.WriteLine(poäng3 + " poäng");
        Console.WriteLine();
    sakta(mes4,tid);
        Console.WriteLine(poäng4 + " poäng");
        Console.WriteLine();
        Console.WriteLine(fullpoäng);


    spelomgångar[såkandetvara] = fullpoäng.ToString();
}

int öö = 0;
foreach(string lalal in spelomgångar){
    öö++;
    Console.WriteLine("om gång " + öö + " blev " +lalal);
}






static void åjaghardetkortet(int vemkör, List<string> spelare, string[] aiminne, ref string check , ref int spelareval){
    int tid = 60;
    for(int i = 1; i != 5; i++){
        if(spelare.Contains(aiminne[i]) && i != vemkör){
            check = aiminne[i];
            spelareval = i;
        }
    }
}

static void sakta(string mes, int tid){
    foreach (char c in mes){
        Console.Write(c);
        Thread.Sleep(tid);
    }
    Console.WriteLine();
}

static void aivälja(ref int spelareval, int vemfrågar, ref int vemdunyssfråga){
            int tid = 60;
            Random r = new Random();
            spelareval = r.Next(1,5);
            int plusminus;

            if(spelareval == vemfrågar){
                plusminus = r.Next(1,3);
                if(plusminus == 1){
                    if(spelareval != 1){
                        spelareval--;
                        if(spelareval == vemdunyssfråga){
                            if(spelareval != 1){
                                spelareval--;
                            }
                            else{
                                spelareval += 2;
                            }
                        }
                    }
                    else{
                        spelareval++;
                        if(spelareval == vemdunyssfråga){
                            spelareval++;
                        }
                    }
                }
                else{
                    if(spelareval != 4){
                        spelareval++;
                        if(spelareval == vemdunyssfråga){
                            if(spelareval != 4){
                                spelareval++;
                            }
                            else{
                                spelareval -= 2;
                            }
                        }
                    }
                    else{
                        spelareval--;
                        if(spelareval == vemdunyssfråga){
                            spelareval--;
                        }
                    }
                }
            }
            else if(spelareval == vemdunyssfråga){
                plusminus = r.Next(1,3);
                if(plusminus == 1){
                    if(spelareval != 1){
                        spelareval--;
                        if(spelareval == vemfrågar){
                            if(spelareval != 1){
                                spelareval--;
                            }
                            else{
                                spelareval += 2;
                            }
                        }
                    }
                    else{
                        spelareval++;
                        if(spelareval == vemfrågar){
                            spelareval++;
                        }
                    }
                }
                else{
                    if(spelareval != 4){
                        spelareval++;
                        if(spelareval == vemfrågar){
                            if(spelareval != 4){
                                spelareval++;
                            }
                            else{
                                spelareval -= 2;
                            }
                        }
                    }
                    else{
                        spelareval--;
                        if(spelareval == vemfrågar){
                            spelareval--;
                        }
                    }
                }
                
            }
        }

static void ingakort(int vemkör, ref List<string> kortlek, ref List<string> spelare, Random r){
    int tid = 60;
    if(kortlek.Count != 0 && spelare.Count != 0){
        spelare.Add(DraKort(kortlek,r));
    }
}

static void drakort_frånhand(int vemdufrågar, ref List<string> få_hand, ref List<string> ta_hand, string check, ref int föratt, int vemkör){
    int antal = 0;
    int tid = 60;
    string mes1 = "Spelare "+ vemkör + " frågar spelare " + vemdufrågar+ " efter " + check +" spelare "+ vemdufrågar +" hade inga, dra från sjön";
    string[] anta = ["Null", "en ", "två ", "tre "];
    if(ta_hand.Contains(check)){
    
        do{
            ta_hand.Remove(check);
            få_hand.Add(check);
            antal++;
        }while(ta_hand.Contains(check));
        string mes2 = "Spelare "+ vemkör +" frågar spelare " + vemdufrågar + " och de Hade " + anta[antal] + check;
        sakta(mes2, tid);
        föratt = 1;    
    }
    else{
        föratt = 0;
        sakta(mes1, tid);
    }
}

static string DraKort(List<string> kortlek, Random r){
    int index = r.Next(kortlek.Count);         // Dra ett slumpmässigt index
    string kort = kortlek[index];           // Få kortet på det indexet
    kortlek.RemoveAt(index);                // Ta bort kortet från kortleken
    return kort;                            // Returnera kortet
}

static void vadhardeförkort(List<string> spelare){
    foreach(string dinhand in spelare){
        Console.Write(dinhand + " ");
        Thread.Sleep(50);
    }
    Console.WriteLine();
    Console.WriteLine();
}

static void harde4(ref int fullpoäng, ref List<string> hand, ref int poäng, ref string check , int vemkör){
    int tid = 60;
    Random r = new Random();
    string[] k13 = {"Ess","2","3","4","5","6","7","8","9","10","Knäkt","Dam","Kung"};
    foreach(string kortfucker in k13){
        
        int harde4 = hand.FindAll(kort => kort == kortfucker).Count;
        if(harde4 == 4){
            string mes1 = "Spelare " + vemkör + " hade 4 av " + kortfucker + " och får 1 poäng." ;
            sakta(mes1, tid);

            hand.RemoveAll(kort => kort == kortfucker);
            poäng++;
            fullpoäng++;

            
            if(hand.Count != 0){
                check = hand[r.Next(0,hand.Count)];
            }
            else{
                check = "";
            }           
        }          
    }
}

static void fel(string fel){
    Console.WriteLine("fel i "+fel);
}